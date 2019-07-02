<p align="center">
    <a href="https://mohghaderi.github.io/utd.tricorder.docs/"><img src="/static/utd-tricorder-icon.svg" width="160" alt="Tricorder Icon" /></a>
</p>
<h3 align="center"><a href="https://mohghaderi.github.io/utd.tricorder.docs/">UTD.Tricorder</a></h3>
<p align="center">A platform to develop web-based telemedicine research applications
    <p>
        <p align="center">
            <a href=""><img src="https://badgen.net/badge/license/public domain/f2a" alt="License"></a>
            <img src="https://badgen.net/badge//windows?icon=windows" alt="Windows">
        </p>
    </p>
</p>

---


[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fmohghaderi%2Futd.tricorder.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fmohghaderi%2Futd.tricorder?ref=badge_large)

### Notes

This project started in 2013 and the development stopped in 2015.
It was intended to be used as a single research application, and 
the main goal was to research new software architectures and innovate software engineering techniques.
Therefore, you may find many technologies are not used the way is used in other projects, 
and in some cases it maybe difficult to understand the design decisions behind it.

In addition, the source code was maintained on Visual Studio Online TFS (Azure DevOps), and it wasn't possible to extract commit history.
DLLs and dependencies pushed to the source control because that was the only way to use VSTS build server back then. 
As a result, I don't expect anyone to easily start using this.

Despite the above facts and some others, I decided to released the source code in case somebody was interested to use it as is.
I am willing to help you with your research project in my free time.

### New version
The upgraded version of this project is fully redesigned according to the best practices and is under development in a private Git repository.
I am planning to open-source that one, too. However, if you're interested to have access to that source earlier, please feel free to email me.
With that being said, this alpha release will be the last release of this series.

### How to use

To start using the project, you need to download the latest release from the [project website](https://mohghaderi.github.io/utd.tricorder.docs/).
You can customize the application by modifying the source code. The project doesn't have a separate documentation.

### Pre-requisite
- [Visual Studio Community Edition (2017+)](https://visualstudio.microsoft.com/downloads/)
- [SQL Server Express (2016+)](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- [AWS account](https://aws.amazon.com/) Needed for file uploads or deployments only
- Knowledge of C#, AngularJs, SQL Server

### Packages
This is an old code and packages weren't supported on VSTS build system.
Download and extract in the root of the project
https://github.com/mohghaderi/utd.tricorder/releases/download/v0.0.1-alpha/packages.zip
Download and extract Scripts to UTD.Tricorder.Website project
https://github.com/mohghaderi/utd.tricorder/releases/download/v0.0.1-alpha/Scripts.zip

### Database
Extract the database zip file from Db folder.
Open the file in SQL Server Management Studio and run to create the database on your SQL Express
Create a new Database named Tricorder and run the sql file provided in the zip.

### serverinfo.config
Open the sln file in Visual Studio.
Use Find and replace (Ctrl+Shift+H) to replace configuration variables in files
Replace	`win-rqtm81i5tjb` with your windows machine name

### hosts
Run Notepad in Administrator mode and open `C:\Windows\System32\drivers\etc\hosts` file
Add the following line there
127.0.0.1	xecarelocal.com
127.0.0.1	utsw.xecarelocal.com
127.0.0.1	hamad.xecarelocal.com

open TricorderSolution\.vs\config\applicationhost.config and find
`site name="UTD.Tricorder.Website"` tag and add the following bindings:
'''
<binding protocol="http" bindingInformation="*:9343:localhost" />
<binding protocol="http" bindingInformation="*:9343:*" />										
<binding protocol="https" bindingInformation="*:44300:localhost" />
<binding protocol="https" bindingInformation="*:44300:*" />		
'''

you should be able to load the other app using subdomains in your browser:
http://hamad.xecarelocal.com:9343

Open TricorderSolution\UTD.Tricorder.Website\Base\Helpers\SiteUI.cs to add or modify subdomains
SiteDomains table in the database is not used. Site files are stored in Sites folder; however, it is better to replace the files
to avoid complications.

### Test Projects
Test projects are very old and may not work with VS 2017. Use JetBrains Resharper Test Runner to run test cases.
https://www.jetbrains.com/resharper/

### *.config file
If you would like to enable third party services such as file upload, email sending or SMS sending, 
register in the website (AWS, Twilio, etc.) and put the values in the config file. 
There are many config file. So, use Replace in Files feature (CTRL+SHIFT+H) to replace your config values.

### Start the project
Set UTD.Tricorder.Website as startup and run.
You should be able to use the following accounts to login to the system:

Username: demopatient
Password: Demo123

Username: demodoctor
Password: Demo123

## Deployments
There is no automated deployment in the project. Get your own server and deploy your code there.
You may use AWS EC2, RDS, S3, Dynamo, etc. for deployments.

### Security Replacements
Open `TricorderSolution\Framework\Common\Utils\EncryptionUtils.cs`
and put a new random string for your encryptions

Open `TricorderSolution\Framework\Common\Security\PasswordHash.cs`
and put a new random string for your password hashes

This may prevent you to login with current demo accounts.

Open `TricorderSolution\UTD.Tricorder.Website\app\app.js`
and replace clientSecret with your secret key. 
Open `WebApiClient` table in the database and put your secret there


## License
[![CC0](http://mirrors.creativecommons.org/presskit/buttons/88x31/svg/cc-zero.svg)](https://creativecommons.org/publicdomain/zero/1.0/)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fmohghaderi%2Futd.tricorder.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Fmohghaderi%2Futd.tricorder?ref=badge_shield)

This source code is released under Public Domain.
The code for the libraries and the scripts inside of the release is NOT under public domain, but they should all be under MIT or Apache 2.0 license and allow commercial usage.
I am NOT responsible for any licensing infringements, and the responsibilities of using this code anywhere goes back to the person who uses it.
There are few classes that are copied from the Internet samples. I tried to put the related URLs, but there might be some code not written by me.