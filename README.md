# consultare.gov.ro
Platforma pentru centralizarea initiativelor legislative aflate in dezbatere publica

# Descrierea problemei
În prezent, instrumentele prin care cetățenii pot lua parte în mod direct la decizii nu sunt suficient de cunoscute la nivelul populației largi. Ministerul pentru Consultare Publică realizează deja, prin colectarea manuală a proiectelor de acte normative aflate în consultare publică un buletin informativ numit „E-Consultare”, diseminat către câteva mii de organizații și persoane interesate. 

Deși există oportunitatea de a transmite direct sugestii, instituțiile reclamă că uneori, la nivelul unor acte normative, există foarte puține propuneri primite, deși subiectele sunt de interes larg pentru societate.

# Solutie propusa
În prezent, toate actele normative, cu adresele și link-uri către textul lor se regăsesc într-un fișier .xls, realizat de Ministerul pentru Consultare Publică și Dialog Civic, însă acestea ar putea fi ușor integrate, într-o platformă prietenoasă, cum ar fi consultare.gov.ro.

Ca etapă ulterioară de dezvoltare, ar fi ideal ca aceste proiecte să fie preluate în mod automat din site-urile instituțiilor, de la secțiunile „Transparență decizională”. 

După modelul deja implementat de Camera Deputaților, această plaftormă ar putea cuprinde în mod automat un buton „Trimite propunere”, care să afișeze un scurt formular pentru trimiterea propunerii la respectivul act normativ, iar la momentul apăsării send, să fie trimis un e-mail la adresa de contact pusă la dispoziție de fiecare instituție publică în anunțul actului normativ. 
http://www.cdep.ro/pls/proiecte/upl_pck2015.proiect?cam=2&idp=15989

De asemenea, un alt aspect important ce poate fi realizat este evidențierea termenului pana la care cetățenii pot transmite propuneri și data la care a fost încărcat anunțul. 

O altă funcționalitate a platformei ar fi ca pentru o anumită categorie de utilizatori (cei înscriși în www.ruti.gov.ro) să se trimită o alertă atunci când un minister a încărcat un act normativ în consultare publică, în funcție de domeniul de interes selectat de respectivul utilizator. 

Setul de date există deja, fiind în prezent, centralizat manual de echipa Ministerului pentru Consultare Publică și Dialog Civic, este nevoie doar de transformarea lui în unul accesibil, într-o platformă web.

# Tehnologii:
Microsoft .NET Web API

Microsoft SQL Server

AngularJS 2


# Doresti sa contribui?
Contacteaza-ne sau trimite un e-mail la carol.braileanu@ithub.gov.ro.

# Instalare

## Web API

Deschide proiectul WebApi cu Visual Studio 2015, seteaza proiectul Consultare.Database ca startup project

In Package Manager Console selecteaza proiectul Consultare.Database si ruleaza Update-Database

Creaza site pentru proiecul WebApi cu root in WebApi\Consultare.WebApi\. Implicit este folosita adresa: http://localhost:90.

Build

## Frontend

Instaleaza `Node.js`

Instaleaza angular-cli: `npm install angular-cli -g`

In Command Prompt mergi in folderul ConsultareWeb si ruleaza `npm install`

Seteaza adresa pentru WebApi in `src\environments\environment.ts`

Build cu `ng build`

Watch cu `ng build --watch`

Test cu `ng start`

Lint cu `ng lint` `// Please lint your code before pushing`
