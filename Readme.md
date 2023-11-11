# Learn how send mails using Dotnet 6 and MailKit

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Brief description of your course training project.

## Table of Contents

- [Course Overview](#course-overview)
- [Prerequisites](#prerequisites)
- [Curriculum](#curriculum)
- [Installation](#installation)
- [License](#license)

## Course Overview

Welcome to the Dotnet 6 MailKit Course Project! This project serves as a practical learning experience for creating and sending emails using MailKit in a .NET 6 environment.

## Prerequisites

Before you begin, ensure you have the following prerequisites installed:
- Basic knowledge of C# and .NET
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2022](https://visualstudio.microsoft.com/visual-cpp-build-tools/) Or any IDE or code editor that supports C# and .NET

## Curriculum

Outline the curriculum with a brief description of each module or section. You can include links to detailed documentation or external resources.

1. **Lesson 1: Introduction**
2. **Lesson 2: Installation of Mailkit**
3. **Lesson 3: Send a basic mail**
4. **Lesson 4: Integrate a service**
4. **Lesson 5: Use configuration .NET configuration**
5. **Lesson 5: Use HTML template**



## Installation

### Run the project

Navigate to the project's root directory and use the following command to restore the project's dependencies:

```bash
git clone https://github.com/ivoiredevacademy/sending-mail-with-dotnet6
cd sending-mail-with-dotnet6
dotnet restore
```


### Configuration

Open the `appsettings.json` file and configure the email settings:

```json
{
  "Mail": {
    "Host": "your-smtp-server",
    "Username": "your-smtp-username",
    "Password": "your-smtp-password",
    "FromAdress": "your-email@example.com",
    "Port": 587
  }
}
```

### Run the Project

Execute the following command to run the .NET project:

```bash
dotnet run
```

This command will build and start your project. Open your web browser and navigate to https://localhost:7080/ to interact with the application.

## License

This project is licensed under the MIT License.