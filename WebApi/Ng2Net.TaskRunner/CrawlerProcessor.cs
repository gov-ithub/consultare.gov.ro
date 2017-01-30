using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ng2Net.Model.Scheduler;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastrucure.Logging;
using Ng2Net.Model.Business;
using Ng2Net.Services;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.Xsl;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Ng2Net.TaskRunner
{
    public class CrawlerProcessor
    {
        public int SuccessfulCrawledSites { get; set; }
        public int FailedCrawledSites { get; set; }
        public int TotalCrawledSites { get; set; }
        private CrawlerProcessorSettings _settings;
        private IRepository<CrawlerConfiguration> _configRepository;
        private IRepository<Proposal> _repository;

        public CrawlerProcessor(IRepository<Proposal> repository, IRepository<CrawlerConfiguration> configRepository, CrawlerProcessorSettings settings)
        {
            this._repository = repository;
            this._configRepository = configRepository;
            this._settings = settings;
        }

        public string LogFileName { get; set; }

        public int ProcessQueue()
        {
            //log.LogMessage(" ");
            //log.LogMessage("=================================================");
            //log.LogMessage("Notifier started");
            //log.LogMessage("=================================================");

            //log.LogMessage("Loading items...");
            List<CrawlerConfiguration> query = this._configRepository.GetMany(n => n.Active == true).ToList();
            //log.LogMessage("Found " + query.Count() + " items to process. Sending notifications...");
            foreach (CrawlerConfiguration site in query)
            {
                TryCrawlSite(site);
            }
            //log.LogMessage(this.TotalNotifications + " notifications processed; " + this.SuccessfulNotifications + " successful notifications; " + this.FailedNotifications + " failed notifications");
            return this.SuccessfulCrawledSites;
        }

        public string LogException(Exception ex)
        {
            string shortMessage = ex.Message;
            Exception exc = ex;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                shortMessage += " : " + exc.Message;
            }

            string message = shortMessage + "\r\n" + exc.StackTrace;
            Logging.LogMessage(message);
            return shortMessage;
        }


        private void CrawlSite(CrawlerConfiguration site)
        {
            string rawDocument = Utils.DownloadHttpString(site.Url, _settings.CrawlAtemptTimeout).Replace("\r\n", "");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(rawDocument);

            MemoryStream memStream = new MemoryStream();
            byte[] data = Encoding.Default.GetBytes(site.XsltConfig);
            memStream.Write(data, 0, data.Length);
            memStream.Position = 0;


            XmlReader xsltReader = XmlReader.Create(memStream);

            XslCompiledTransform xsltTransform = new XslCompiledTransform();
            xsltTransform.Load(xsltReader);

            StringWriter sw = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;

            XmlWriter writer = XmlWriter.Create(sw, settings);
            XmlReader xmlReadB = new XmlTextReader(new StringReader(htmlDocument.DocumentNode.OuterHtml));
            xsltTransform.Transform(htmlDocument, null, writer);

            //process output
            XDocument xdoc = XDocument.Parse(sw.ToString());
            var rows = xdoc.Elements("rows").Elements("row");
            foreach (var row in rows)
            {
                CspParameters cspParams = new CspParameters();
                cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

                // Create a new RSA signing key and save it in the container. 
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                string signedRowXml = string.Empty;
                SignXmlFile(row.ToString(), out signedRowXml, rsaKey);


                var signedDocument = Utils.Base64Encode(signedRowXml);

                var proposal = _repository.Get(x => x.ProposalSignature == signedDocument);
                if (proposal == default(Proposal))
                {
                    DateTime date = new DateTime();
                    if (row.Element("date") != null && row.Element("date").Value != string.Empty)
                    {
                        date = Convert.ToDateTime(row.Element("date").Value);
                    }

                    string email = string.Empty;
                    if (row.Element("email") != null && row.Element("email").Value != string.Empty)
                    {
                        email = row.Element("email").Value;
                    }

                    DateTime limitDate = new DateTime();
                    
                    if (row.Element("days") != null && row.Element("days").Value != string.Empty)
                    {
                        limitDate = date.AddDays(Convert.ToInt32(row.Element("days").Value));
                    }
                    else
                    {
                        limitDate = date.AddDays(_settings.DefaultDaysLimit);
                    }

                    DateTime endDate = limitDate;

                    string title = string.Empty;
                    if (row.Elements("body").Count() > 0)
                    {
                        title = row.Elements("body").First().Value;
                    }

                    string description = string.Empty;
                    if (row.Elements("body").Count() > 0)
                    {
                        description = string.Join("<br />", row.Elements("body").Select(x => x.Value));
                    }

                    List<ProposalDocument> documents = null;
                    if (row.Elements("file").Count() > 0)
                    {
                        documents = row.Elements("file").Select(x => new ProposalDocument() { Name = new Uri(x.Value).LocalPath, Type = Path.GetExtension(new Uri(x.Value).LocalPath), Url = x.Value }).ToList();
                    }

                    proposal = new Proposal()
                    {
                        StartDate = date,
                        Email = email,
                        LimitDate = limitDate,
                        EndDate = endDate,
                        InstitutionId = site.InstitutionId,
                        Link = site.Url,
                        ProposalSignature = signedDocument,
                        Title = title,
                        Description = description,
                        ProposalDocuments = documents
                    };
                    _repository.Insert(proposal);
                    _repository.Save();
                }
            }
            xmlReadB.Close();
            writer.Close();
            sw.Close();
        }

        public void SignXmlFile(string xmlString, out string signedXmlString, RSA Key)
        {
            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using it's name.
            doc.Load(new MemoryStream(UTF8Encoding.Unicode.GetBytes(xmlString)));

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document. 
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);


            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)Key));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            signedXmlString = doc.InnerXml;

            // Save the signed XML document to a file specified
            // using the passed string.

        }
        // Verify the signature of an XML file and return the result.
        public Boolean VerifyXmlFile(String signedXmlString)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Format using white spaces.
            xmlDocument.PreserveWhitespace = true;

            // Load the passed XML file into the document. 
            xmlDocument.Load(new MemoryStream(UTF8Encoding.Unicode.GetBytes(signedXmlString)));

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.
            return signedXml.CheckSignature();
        }


        public void TryCrawlSite(CrawlerConfiguration site)
        {
            try
            {
                CrawlSite(site);
                this.SuccessfulCrawledSites++;
            }
            catch (Exception ex)
            {
                this.FailedCrawledSites++;
            }
            finally { this.TotalCrawledSites++; }

        }
    }


    public class CrawlerProcessorSettings
    {
        public int MaxRetryAttempts { get; set; }
        public int CrawlAtemptTimeout { get; set; }
        public int DefaultDaysLimit { get; set; }
    }
}