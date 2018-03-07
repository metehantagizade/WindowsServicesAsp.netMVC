# WindowsServicesAsp.netMVC
Introduce how to Start and Stop windows service from Asp.net MVC

In this project we introduce 
-how to create windows service by using Toshelf
-how to add quartz scheduler to windows service
-how to start, stop and restart windows service from code
...

First of all you should add line bellow to web.config file inside system.web tag
```html
<identity impersonate="true" userName="username" password="password" />"
```
username and password refer to windows account

Next step is adding System.ServiceProcess dll from add reference panel

-----------------
To create windows service we use Topshelf library 
with Topshelf there is no need to create windows service
first of all add Topshelf dll from nuget to your project
then create new console application
after that create a class with name "MyService"(in this example) that has start and stop method
then create another class with name "ConfigureService" to keep configure code like 
```html
using Topshelf;  
namespace WindowsServiceWithTopshelf  
{  
    internal static class ConfigureService  
    {  
        internal static void Configure()  
        {  
            HostFactory.Run(configure =>  
            {  
                configure.Service < MyService > (service =>  
                {  
                    service.ConstructUsing(s => new MyService());  
                    service.WhenStarted(s => s.Start());  
                    service.WhenStopped(s => s.Stop());  
                });  
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();  
                configure.SetServiceName("MyWindowServiceWithTopshelf");  
                configure.SetDisplayName("MyWindowServiceWithTopshelf");  
                configure.SetDescription("My .Net windows service with Topshelf");  
            });  
        }  
    }  
}  
  ```
  
  after these steps you have a console application act as windows service
  
  To install this project on operating system follow steps bellow:
  - rebuild application as release
  - run CMD as administrator
  - go inside bin/release folder of project
  - type 
  ```html
  MyWindowServiceWithTopshelf.exe install

  //for unistall service type 

  MyWindowServiceWithTopshelf.exe unistall
    ```
  

