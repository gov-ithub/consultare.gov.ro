USE [consultare.gov.start]
GO
DELETE FROM [dbo].[HtmlContents]
GO
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'031e19c1-4735-42aa-ab1b-3d00d36eb7da', N'backend.login.forgotPassword', N'Ai uitat parola?', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'034de04f-47e8-4857-9aed-78c3ce2c13ff', N'backend.errors.userProfile.firstName', N'Introduceti prenumele', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'09c3f713-6f9b-4cc1-a4d2-10870b0f0e18', N'backend.errors.userProfile.email', N'Introduceti o adresa de e-mail valida', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'0bb11030-b0ac-4e2e-bb89-28c51b1ec69a', N'public.proposal.startDate', N'Data publicarii:', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'11910f17-e910-47ff-81bc-f779535d9a43', N'backend.label.startdate', N'Data publicarii', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'167181a9-5731-49ea-8869-fff3aba45d6e', N'email.defaultUrl', N'http://193.230.8.66', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'16ad9821-17dc-4634-88b8-61da50fa73ed', N'backend.httpErrors.email_not_found', N'Adresa de e-mail nu a fost gasita in baza de date', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'1e32c1e5-15f7-4b30-a877-5300d26f9d19', N'public.proposals.hero', N'<section class="hero-bottom"></section>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'1fd17e79-2fd9-44fc-b658-76378ee4735f', N'backend.content.url', N'Url', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'253b39bb-d32a-4ce7-9ae8-554cd13eb73f', N'backend.label.institution', N'Institutie initiatoare', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'29de56b8-acce-4b55-83ed-be9d2db6d6db', N'public.page.about', N'<section class="hero-bottom"></section>

<section class="content container main-content">
<h1>Bine ați venit în aplicația E-Consultare!</h1>

<p>Această aplicație vine, într-o manieră simplă și creativă, în sprijinul celor care urmăresc și au nevoie să se implice, cu sugestii și opinii, în procesul de inițiere a diferitelor acte normative, de către ministere. Prin preluarea (manuală, până la standardizarea paginilor de internet ale ministerelor) tuturor proiectelor de acte normative într-un singur loc, cei care doresc să cunoască dar și să trimită sugestii și opinii inițiatorilor acestor acte normative o pot face foarte ușor întrucât E-consultare oferă, într-un singur loc:</p>


<div class="row about-row">
<div class="col-sm-4">
<div class="about-box">
<img class="icon" src="/assets/public/images/about-icon-1.png">
Lista actelor normative inițiate de fiecare dintre cele 22 de ministere;
</div>
</div>
<div class="col-sm-4">
<div class="about-box">
<img class="icon" src="/assets/public/images/about-icon-2.png">
Infomații despre termenul limită, pentru fiecare act normativ în parte pentru a vă putea planifica să trimiteți opinii în termenul prevăzut pentru consultare;
</div>
</div>
<div class="col-sm-4">
<div class="about-box">
<img class="icon" src="/assets/public/images/about-icon-3.png">
Date despre adesele de email unde se pot trimite aceste comentarii;
</div>
</div>
</div>


<p>Actualizarea acestor informații se face cu o frecvență săptămânală.</p>

<p>România se schimbă, viteza de comunicare afectează și acest domeniu, astfel că E-Consultare reprezintă răspunsul Guvernului la așteptările societății civile față de un proces legislativ eficient și participativ.</p>

<p>E-Consultare este disponibil oricărei persoane fizice sau juridice interesate, locuind fie în România fie în străinătate.</p>

<p>Platforma pe care a fost creată E-Consultare are cod sursă deschis disponibil la https://github.com/gov-ithub astfel că poate fi preluat și adaptat pentru orice alt proiect similar (la nivelul forurilor legislative național și locale). Această platformă a fost dezvoltată de Ministerul pentru Consultare Publică și Dialog Civic (MCPDC) în colaborare cu echipa GovIT Hub din cadrul Cancelariei Prim – Ministrului. </p>

<p>Elaborarea unei propuneri legislative în România se face participativ, conform legii nr. 52/2003 privind transparența decizională:
<ul style="padding-left: 20px">
<li>Instituțiile inițiatoare publică un anunț privind actul normativ aflat în consultare publică, adresa la care se pot transmite sugestii și termenul de primire a sugestiilor, cu cel puțin 30 de zile înainte de avizarea actului normativ;</li>
<li>Termenul de primire a sugestiilor este de cel puțin 10 zile de la publicarea anunțului;</li>
<li>Inițiatorii sunt obligați să răspundă în scris tuturor celor care au transmis propuneri și să justifice preluarea / nepreluarea recomandărilor formulate şi înaintate în scris de cetăţeni şi asociaţiile legal constituite ale acestora.</li>
</ul>
</p>

</section>

', N'despre')
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'30aae42f-d645-49ef-95e8-9fa76f0beee6', N'public.proposals.dateExpired', N'(termenul a expirat)', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'32d9b598-e22c-4ea0-9be3-b7dfb25e1064', N'backend.content.edit', N'Editeaza continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'33ba3386-b860-4098-9775-7373a5dab2cc', N'public.page.contact', N'<section class="hero-bottom"></section>
', N'contact')
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'39a2c52e-3aaa-443f-9e55-f91edf51440b', N'backend.httpError.email_sent', N'E-mailul a fost trimis cu succes. Va rugam verificati casuta de mail si urmati instructiunile.', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'3cf05f33-3e19-4424-9079-39c330430749', N'backend.login.signin', N'Intra in cont', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'3feeac33-5b38-43f8-b196-fb856c815df6', N'backend.content.page.contentlist.title', N'Administrare continut <small>administrare zone de continut</small>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'440928f0-0555-4522-b425-68d944883671', N'email.confirm-account.body', N'Salut {{FULLNAME}},
<br /><br />
Contul tau a fost creat cu succes. Te rugam sa faci click pe link-ul de mai jos pentru a confirma inscrierea la buletinele informative E-consultare:
<a href="{{ROOT_URL}}{{LINK}}">Click aici</a>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'47d22f93-3b5f-4721-b4c8-30d846cbdc68', N'backend.menu.content', N'Continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'486824a8-3531-403b-8839-c1aa6b1e51b9', N'backend.label.limitdate', N'Data limita pentru trimiterea propunerilor', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'4a588d58-a4d3-4507-8090-336f1527e59c', N'backend.httpError.password_reset_failed', N'Link invalid. Va rugam incercati din nou.', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'4ae99bb3-1499-4997-87f7-23f83a96c1b3', N'backend.content.content', N'Continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'4edd782c-9c78-4ca9-b0b4-9d7d620172a2', N'email.masterTemplate', N'Ministerul pentru Consultare

{{CONTENT}}', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'5454c21d-a41d-48a3-b6b4-49c51dc3be7d', N'backend.content.page.contentlist.search', N'Cauta', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'58dbb908-1d41-49ac-a8a3-7f4691cf2b3e', N'backend.errors.userProfile.acceptTos', N'Trebuie sa acceptati termenii si conditiile de utilizare pentru a va intregistra', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6556056b-6170-424a-8de6-a13bc4253a32', N'backend.menu.logout', N'Iesire din cont', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'67c26788-a08e-45de-8a2b-65af6ccfbf08', N'backend.login.password', N'parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6c3c5b77-04d6-4c32-974f-1af065517c6b', N'backend.errors.login.password', N'Parola trebuie sa aibe minim 6 caractere', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6e540a40-7b44-40fb-98aa-f1b790aa69e3', N'backend.content.save', N'Salveaza continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'757ad10c-94ad-4138-bad1-3f0b73d51502', N'public.home.contact', N'<section class="contact">
<div class="container">
<div class="row">
<div class="col-md-4 text-center">
<img style="width:100%; max-width:300px" src="assets/public/images/logomcpdc.png" />
<br /><br />
<a href="mailto:informare@dialogcivic.gov.ro" style="font-weight:bold">informare@dialogcivic.gov.ro</a>

<div class="text-muted">Piata Victoriei 1,<br />
Bucuresti, Romania</div>
</div>

<div class="col-md-4 text-center">
<h1>Social media</h1>
&nbsp;

<ul class="social-network social-circle">
	<li><a class="icoFacebook" href="https://www.facebook.com/mcpdc" target="_blank" title="Facebook"><i class="fa fa-facebook"></i></a></li>
	<li><a class="icoTwitter" href="#" title="Twitter"><i class="fa fa-twitter"></i></a></li>
	<li><a class="icoLinkedin" href="#" title="Linkedin"><i class="fa fa-linkedin"></i></a></li>
</ul>
</div>

<div class="col-md-4 text-center">
<h1>Un proiect dezvoltat de</h1>
<a href="http://ithub.gov.ro" target="_blank"><img style="max-width:150px; width:100%" src="/assets/images/sigla-govithub.png"></a></div>
</div>
</div>
</section>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'7974cdd3-8c47-45db-b81a-7d7753b2fa98', N'public.proposals.viewall', N'Vezi toate propunerile legislative', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'7ab9f2c4-37f5-4c08-bb70-9ab58d84ab57', N'backend.content.page.proposals.title', N'Propuneri legislative <small>administrare propuneri</small>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'84d48b1e-2270-4624-90b9-b2c282cc6fb1', N'backend.errors.userProfile.lastName', N'Introduceti numele', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'8801d818-9889-4a62-8c84-cc1ca9a28d10', N'backend.menu.navigation', N'Meniu Principal', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'891fc2db-e7f5-4393-8f6a-db5d0a8ec2c8', N'email.confirm-account.subject', N'Confirma contul tau pe consultare.gov.ro', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'89898486-c11d-40a1-8c9e-8c77b65f3a2e', N'backend.login.email', N'adresa e-mail', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'8a636a2f-d2cc-41d7-bc0d-2fd1edf94f56', N'public.home.hero.bottom', N'<section class="hero-bottom">
<div class="heroContent container">
Participa la <br />
dezbaterea publica
<div class="heroSubtitle">Lorem Ipsum is simply dummy text of the printing <br />
and typesetting industry been the industry''s</div>
<a onclick="window.angular.parentComponent.openSignUp(); return false;" class="btn btn-primary btn-lg">Inscrie-te acum!</a>
</div>

</section>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'8ab7ac03-ac7a-40d4-9846-2bc1043f139d', N'backend.login.prompt', N'Introduceti adresa de e-mail si parola pentru autentificare', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'956806f5-2abc-4331-afd7-6d71c94663e7', N'backend.label.email', N'E-mail', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'96aacdbf-0429-4333-b4d4-99416a1997cc', N'backend.label.initiatingInstitution', N'Initiator', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'9ee801e9-a173-4664-b1ed-d4321d3a8573', N'backend.content.delete', N'Sterge', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'a5c6370a-1e59-4ff4-a732-4413b3ce9b0a', N'public.proposals.sortby', N'Sorteaza dupa:', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'ac66fddc-e08f-4f71-9cdd-4d4c1dd3060e', N'public.home.hero', N'<section class="hero">
<div class="heroContent container">
Participa la <br />
dezbaterea publica
<div class="heroSubtitle">Creeaza-ti cont pentru a primi newsletter-ul saptamanal<br />
cu propunerile legislative in dezbatere publica.</div>
<a onclick="window.angular.parentComponent.openSignUp(); return false;" class="btn btn-primary btn-lg">Inscrie-te acum!</a>
</div>
</section>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'acafac52-5bc0-4938-aa37-8f724df8aff5', N'backend.errors.userProfile.password', N'Introduceti o parola de minim 6 caractere', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'b3f70e40-afaf-4d94-9a77-8847169ac0e2', N'backend.label.title', N'Titlu', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'b53c605d-7374-41c3-963e-a0d2b24955d2', N'backend.page.home', N'<section class="content-header">
<h1>E-consultare<small>pagina de administrare</small></h1>
</section>
<section class="content">
</section>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'b8174678-ea4c-403c-8b86-a8ebc14ac76f', N'email.reset-password.subject', N'Resetare parola pe consultare.gov.ro', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'bac2005e-3a17-41a2-a31e-b390c7d35c44', N'backend.label.link', N'Link', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'c09f3580-9a8f-4e36-85e9-9b379d0e4683', N'backend.label.enddate', N'Data incheierii dezbaterii publice', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'c3fd6cc7-d67d-49be-adff-106e60118173', N'public.account.unsubscribed', N'Ati fost dezabonat cu succes de la newsletterul e-consultare.', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'c8ac5bac-2c16-41bd-8191-045a1931eb12', N'backend.errors.login.repeatPassword', N'Parolele nu sunt identice', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'cff423ef-39cb-4dbf-97d3-ad23788dcbfc', N'backend.content.name', N'Nume', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd213b94d-be7d-4378-be15-631a91ba3b5c', N'backend.errors.userProfile.repeatPassword', N'Parolele nu sunt identice', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd38b4742-fc17-4272-aefe-8f11890a6439', N'backend.proposal.page.title', N'Propuneri legislative <small>administrare detalii</small>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd6d1ff64-bde9-46f7-a166-caef3362d819', N'backend.menu.proposal', N'Propuneri legislative', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd7da6ce5-0113-43df-8a30-a2fc321f7d78', N'public.home.footer', N'<footer>
<div class="container">
<div class="row">
<div class="col-md-8">
<a onclick="window.angular.parentComponent.navigateUrl(''/propuneri-legislative'');">Propuneri legislative</a>
|
<a onclick="window.angular.parentComponent.navigateUrl(''/p/despre'');">Despre proiect</a>
|
<a onclick="window.angular.parentComponent.navigateUrl(''/p/contact'');">Contact</a>
</div>

<div class="col-md-4 text-right">Copyright &copy; 2016 MCPDC</div>
</div>
</div>
</footer>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd96156cf-7ac6-454c-bd81-5fa2bb1047f2', N'backend.login.repeatPassword', N'repeta parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e159cfe5-76fd-4215-924a-a4a93b114cbb', N'backend.httpError.account_confirmed', N'Contul tau a fost activat. Multumim.', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e2aff455-0943-4c66-b1bf-33514e1ed4e3', N'backend.httpError.password_reset', N'Parola resetata cu succes', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e4bc99c4-9d2a-407a-9a6a-01afdb928bb2', N'public.proposal.endDate', N'Data incheierii dezbaterii publice:', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e51405b1-8f57-4f09-8e93-07257af63dc3', N'backend.resetPassword.prompt', N'Reseteaza parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e53c8a5e-73bf-43e8-bf4a-095204839a4b', N'public.proposal.limitDate', N'Limita pentru trimitere propuneri:', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e8ae3076-2bb5-40ed-aea0-8f7cf9f257d3', N'public.signup.result', N'Contul tau a fost creat. Te rugam sa verifici casuta de e-mail cu care te-ai inregistrat pentru a confirma adresa de e-mail.
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'ee849ac1-ece6-453a-b200-063268bc2e70', N'backend.content.page.contentlist.boxtitle', N'Zone continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'f0ce4858-457b-4ebb-b6f0-4f29ca9dc47a', N'email.reset-password.body', N'Salut {{FULLNAME}},
<br /><br />
Pentru a reseta parola pe site-ul consultare.gov.ro, te rugam sa faci click pe link-ul de mai jos. Daca nu ai soclicitat resetarea parolei te rugam sa ignori acest e-mail.
<a href="{{ROOT_URL}}{{LINK}}">Click aici</a>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'f2f84dd0-fe24-4e9f-bcc8-718105e0b455', N'backend.forgotPassword.prompt', N'Introduceti adresa de e-mail', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'feb21c4c-6791-4930-b360-d4354e4ab89e', N'backend.httpErrors.email_sent', N'E-mailul a fost trimis cu succes', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'fed280ef-2ae7-4102-a668-909ac2e5fe6f', N'email.defaultFrom', N'E-Consultare <informare@dialogcivic.gov.ro>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd8c0b152-79c4-487c-89c7-c9f9f018852c', N'backend.content.page.institutions.title', N'Administrare institutii', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6582066f-20c9-4ddf-a81a-8364d7dde686', N'backend.menu.institution', N'Institutii', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'2a5ac8a6-3572-40ad-bdfb-36491a7edaa6', N'backend.content.type', N'Tip', NULL)
