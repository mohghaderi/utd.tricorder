Current visual studio doesn't copy the whole folder, but it copies all the files inside the folder if
attribute tag [DeploymentItem("_Config\\")] is added to the TestClass.

tzdb2014e.nzd is related to timeZone. It is not a configuration file, but it is required to
be exists for some database related activities in order to convert a date to the user's 
local date time. It was located in another folder, but I moved it to this folder to prevent adding
another DeploymentItem tag to all TestClasses.