# WindowsServicesAsp.netMVC
Introduce how to Start and Stop windows service from Asp.net MVC

At first you should add line bellow to web.config file inside system.web tag
-<identity impersonate="true" userName="username" password="password" />
-username and password refer to windows account

Next step is adding System.ServiceProcess dll from add reference panel

