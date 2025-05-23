# 💾 EasySave – Intelligent Backup Application

**EasySave** is a modular desktop backup application designed to help users create, manage, and execute efficient file backups. The application exists in two forms:

1. **Console Application (v1 – Prototype)**  
2. **Graphical Desktop Application (v2 – MVVM)**

This project was developed using **C#**, the **.NET Core 3.x** framework, and adheres to modern development standards including **version control**, **UML design modeling**, and a scalable architecture.

---

## 🎯 Project Goals

- Provide a reliable, maintainable backup system
- Support different types of backups (full, differential)
- Ensure clean, modular design using object-oriented programming
- Prepare the codebase for future enhancements and enterprise use

---

## 🖥️ GUI Application (v2 – MVVM Architecture)

The advanced version of EasySave is built using **WPF with MVVM architecture**, offering:

- ✅ Intuitive user interface for job management
- ✅ Automatic file selection based on type/priority
- ✅ File encryption and decryption during backup
- ✅ Filtering to ignore temporary or system files
- ✅ Progress bars and execution logs
- ✅ Secure job logging and serialization

> The GUI version enhances the basic backup features by adding smart logic to determine what should be backed up, and offers a more user-friendly experience for non-technical users.

---

## ⚙️ Console Application (v1 – Livrable 0)

The initial prototype is a .NET Core console app with these core features:

- ✅ Create and manage backup jobs via command line
- ✅ Log backups to a JSON/text file
- ✅ Select language and localization preferences
- ✅ Basic UML-modeled structure (Prime & MainMenu classes)

---

## 🧪 Technology Stack

| Component            | Technology                     |
|---------------------|---------------------------------|
| Language            | C#                              |
| Framework           | .NET Core 3.x                   |
| IDE                 | Visual Studio 2022              |
| Architecture (GUI)  | MVVM (Model-View-ViewModel)     |
| Version Control     | Git                             |
| Collaboration       | Azure Boards (DevOps tracking)  |

---

## Note :
you need to install this specific .Net framework for it to work: ```https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=6.0.0&arch=x64&rid=win-x64&os=win10```

## 📂 UML & Design Modeling

The following UML diagrams were created to define the structure and flow of the system:

- Use Case Diagram
- Class Diagram
- Activity Diagram
- Sequence Diagrams

These diagrams guided the initial development and help ensure code maintainability and clarity.

---

## 🔒 Key Features

- ✅ Modular backup job creation
- ✅ Advanced file filtering logic
- ✅ Encryption/Decryption of backed-up files
- ✅ User-friendly GUI (WPF/MVVM)
- ✅ Localization support
- ✅ Logs for monitoring and debugging
