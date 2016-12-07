USE [consultare.gov.start]
GO
DELETE FROM [dbo].[HtmlContents]
GO
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'031e19c1-4735-42aa-ab1b-3d00d36eb7da', N'backend.login.forgotPassword', N'Ai uitat parola?', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'16ad9821-17dc-4634-88b8-61da50fa73ed', N'backend.httpErrors.email_not_found', N'Adresa de e-mail nu a fost gasita in baza de date', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'1e32c1e5-15f7-4b30-a877-5300d26f9d19', N'public.proposals.hero', N'<section class="hero-bottom"></section>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'1fd17e79-2fd9-44fc-b658-76378ee4735f', N'backend.content.url', N'Url', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'29de56b8-acce-4b55-83ed-be9d2db6d6db', N'public.page.about', N'<section class="hero-bottom"></section>

<section class="content container">
<h1>Bine ați venit în aplicația E-Consultare!</h1>

<p>Această aplicație vine, într-o manieră simplă și creativă, în sprijinul celor care urmăresc și au nevoie să se implice, cu sugestii și opinii, în procesul de inițiere a diferitelor acte normative, de către ministere. Prin preluarea (manuală, până la standardizarea paginilor de internet ale ministerelor) tuturor proiectelor de acte normative într-un singur loc, cei care doresc să cunoască dar și să trimită sugestii și opinii inițiatorilor acestor acte normative o pot face foarte ușor întrucât E-consultare oferă, într-un singur loc:</p>

<div class="container">
<div class="row">
<div class="col-md-4">
1.	Lista actelor normative inițiate de fiecare dintre cele 22 de ministere;
</div>
<div class="col-md-4">
2.	Infomații despre termenul limită, pentru fiecare act normativ în parte pentru a vă putea planifica să trimiteți opinii în termenul prevăzut pentru consultare;
</div>
<div class="col-md-4">
3.	Date despre adesele de email unde se pot trimite aceste comentarii;
</div>
</div>
</div>

<p>Actualizarea acestor informații se face cu o frecvență săptămânală.</p>

<p>România se schimbă, viteza de comunicare afectează și acest domeniu, astfel că E-Consultare reprezintă răspunsul Guvernului la așteptările societății civile față de un proces legislativ eficient și participativ.</p>

<p>E-Consultare este disponibil oricărei persoane fizice sau juridice interesate, locuind fie în România fie în străinătate. Cei care se înscriu pe adresa informare@dialogcivic.gov.ro vor primi cu promptitudine E-Consultare, orice problemă întâmpinați urmând a fi semnalată pe adresa: andreea.grigore@gov.ro.</p>

<p>Platforma pe care a fost creată E-Consultare are cod sursă deschis disponibil la https://github.com/gov-ithub astfel că poate fi preluat și adaptat pentru orice alt proiect similar (la nivelul forurilor legislative național și locale). Această platformă a fost dezvoltată de Ministerul pentru Consultare Publică și Dialog Civic (MCPDC) în colaborare cu echipa GovIT Hub din cadrul Cancelariei Prim – Ministrului. </p>

<p>Elaborarea unei propuneri legislative în România se face participativ, conform legii nr. 52/2003 privind transparența decizională:
<ul>
<li>Instituțiile inițiatoare publică un anunț privind actul normativ aflat în consultare publică, adresa la care se pot transmite sugestii și termenul de primire a sugestiilor, cu cel puțin 30 de zile înainte de avizarea actului normativ;</li>
<li>Termenul de primire a sugestiilor este de cel puțin 10 zile de la publicarea anunțului;</li>
<li>Inițiatorii sunt obligați să răspundă în scris tuturor celor care au transmis propuneri și să justifice preluarea / nepreluarea recomandărilor formulate şi înaintate în scris de cetăţeni şi asociaţiile legal constituite ale acestora.</li>
</ul>
</p>

</section>

', N'despre')
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'32d9b598-e22c-4ea0-9be3-b7dfb25e1064', N'backend.content.edit', N'Editeaza continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'3cf05f33-3e19-4424-9079-39c330430749', N'backend.login.signin', N'Intra in cont', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'3feeac33-5b38-43f8-b196-fb856c815df6', N'backend.content.page.contentlist.title', N'Administrare continut <small>administrare zone de continut</small>', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'47d22f93-3b5f-4721-b4c8-30d846cbdc68', N'backend.menu.content', N'Continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'4a588d58-a4d3-4507-8090-336f1527e59c', N'backend.httpError.password_reset_failed', N'Link invalid. Va rugam incercati din nou.', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'4ae99bb3-1499-4997-87f7-23f83a96c1b3', N'backend.content.content', N'Continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'5454c21d-a41d-48a3-b6b4-49c51dc3be7d', N'backend.content.page.contentlist.search', N'Cauta', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6556056b-6170-424a-8de6-a13bc4253a32', N'backend.menu.logout', N'Iesire din cont', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'67c26788-a08e-45de-8a2b-65af6ccfbf08', N'backend.login.password', N'parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6c3c5b77-04d6-4c32-974f-1af065517c6b', N'backend.errors.login.password', N'Parola trebuie sa aibe minim 6 caractere', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'6e540a40-7b44-40fb-98aa-f1b790aa69e3', N'backend.content.save', N'Salveaza continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'757ad10c-94ad-4138-bad1-3f0b73d51502', N'public.home.contact', N'<div class="container contact">
<div class="row">
<div class="col-md-4 text-center">
<h1>Contact</h1>
Ministerul pentru Consultare Publica si Dialog Civic<br />
<a href="mailto:participa@gov.ro">participa@gov.ro</a>

<div class="text-muted">1 Victoriei Square,<br />
Bucharest, Romania</div>
</div>

<div class="col-md-4 text-center">
<h1>Social media</h1>
&nbsp;

<ul class="social-network social-circle">
	<li><a class="icoFacebook" href="#" title="Facebook"><i class="fa fa-facebook"></i></a></li>
	<li><a class="icoTwitter" href="#" title="Twitter"><i class="fa fa-twitter"></i></a></li>
	<li><a class="icoLinkedin" href="#" title="Linkedin"><i class="fa fa-linkedin"></i></a></li>
</ul>
</div>

<div class="col-md-4 text-center">
<h1>Feedback</h1>
<a class="btn-feedback" onclick="window.angular.parentComponent.navigateUrl(''/admin/login'');return false;">Spune-ne parerea ta <i class="fa fa-bullhorn"></i></a></div>
</div>
</div>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'8801d818-9889-4a62-8c84-cc1ca9a28d10', N'backend.menu.navigation', N'Meniu Principal', NULL)
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
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'9ee801e9-a173-4664-b1ed-d4321d3a8573', N'backend.content.delete', N'Sterge', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'ac66fddc-e08f-4f71-9cdd-4d4c1dd3060e', N'public.home.hero', N'<section class="hero">
<div class="heroContent container">
Participa la <br />
dezbaterea publica
<div class="heroSubtitle">Lorem Ipsum is simply dummy text of the printing <br />
and typesetting industry been the industry''s</div>
<a onclick="window.angular.parentComponent.openSignUp(); return false;" class="btn btn-primary btn-lg">Inscrie-te acum!</a>
</div>

</section>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'c8ac5bac-2c16-41bd-8191-045a1931eb12', N'backend.errors.login.repeatPassword', N'Parolele nu sunt identice', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'cff423ef-39cb-4dbf-97d3-ad23788dcbfc', N'backend.content.name', N'Nume', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd6d1ff64-bde9-46f7-a166-caef3362d819', N'backend.menu.proposal', N'Propuneri legislative', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd7da6ce5-0113-43df-8a30-a2fc321f7d78', N'public.home.footer', N'<footer>
<div class="container">
<div class="row">
<div class="col-md-8"><a  (click)="alert(''a'')">Links</a></div>

<div class="col-md-4 text-right">Copyright &copy; 2016 MCPDC</div>
</div>
</div>
</footer>
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'd96156cf-7ac6-454c-bd81-5fa2bb1047f2', N'backend.login.repeatPassword', N'repeta parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e2aff455-0943-4c66-b1bf-33514e1ed4e3', N'backend.httpError.password_reset', N'Parola resetata cu succes', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e51405b1-8f57-4f09-8e93-07257af63dc3', N'backend.resetPassword.prompt', N'Reseteaza parola', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'e8ae3076-2bb5-40ed-aea0-8f7cf9f257d3', N'public.signup.result', N'Contul tau a fost creat. Te rugam sa verifici casuta de e-mail cu care te-ai inregistrat pentru a confirma adresa de e-mail.
', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'ee849ac1-ece6-453a-b200-063268bc2e70', N'backend.content.page.contentlist.boxtitle', N'Zone continut', NULL)
INSERT [dbo].[HtmlContents] ([Id], [Name], [Content], [Url]) VALUES (N'f2f84dd0-fe24-4e9f-bcc8-718105e0b455', N'backend.forgotPassword.prompt', N'Introduceti adresa de e-mail', NULL)
