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
- [Visual Studio Community Edition (2015+)](https://visualstudio.microsoft.com/downloads/)
- [SQL Server Express (2016+)](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- [AWS account](https://aws.amazon.com/) Needed for file uploads or deployments only
- Knowledge of C#, AngularJs, SQL Server

## License
[![CC0](http://mirrors.creativecommons.org/presskit/buttons/88x31/svg/cc-zero.svg)](https://creativecommons.org/publicdomain/zero/1.0/)

This source code is released under Public Domain.
The code for the libraries and the scripts inside of the release is NOT under public domain, but they should all be under MIT or Apache 2.0 license and allow commercial usage.
I am NOT reponsible for any licensing infrigments, and the responsibilities of using this code anywhere goes back to the person who uses it.
