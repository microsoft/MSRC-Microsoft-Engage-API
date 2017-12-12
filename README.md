

# Welcome
The Microsoft Security Response Center (MSRC) provides the Engage API to allow automated submission of various security reports: abuse or attacks originating from Microsoft online services, planned penetration testing of Azure assets, or security vulnerabilities in Microsoft products and services. The [MSRC Portal](https://portal.msrc.microsoft.com/en-us/engage) provides additional documentation about this API and information about this processes, as well as a graphical user interface ideal for submitting individual reports. This API provides a route for submitting bulk reports programmatically.

This repository contains sample code and documentation for the [MSRC 
Engage API](https://portal.msrc.microsoft.com/en-us/developer). The docs folder contains the API definition in the OpenAPI (Swagger) 2.0 specification. The src folder contains sample client code for the three endpoints, which are:

1. **CARS**: report suspected cyberattacks or abuse originating from Microsoft online services, such as Microsoft Azure, Bing, Outlook, OneDrive, and Office 365.
2. **Pentest**: optionally notify Microsoft of planned penetration testing of your Azure assets.
3. **SSI**: report Microsoft Service Security Issues, such as misconfigurations, vulnerabilities, and other security-related issues.

# API Keys
The Engage API requires an API key. To obtain one, please log into the [MSRC Portal](https://portal.msrc.microsoft.com/) and obtain the key from the Developer tab. Currently, generating an API key requires an @outlook.com, @live.com, or @microsoft.com email address.

# Change Log
Uploaded C#, Python and Ruby code samples as well as CARS Swagger file.

Updated swagger.json and added swagger.yaml.  Uploaded PowerShell Module.

Added Curl, ObjC, Java, JavaScript, and PHP code examples.

# Contributing
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

It is Microsoft’s mission to empower every person and every organization on the planet to achieve more. We thank you for helping shape that future by making the world a more secure place, and we welcome your feedback on features to add or bugs to fix.
