# 🏠 Street Children Care System

A desktop application built with **C# (.NET Windows Forms)** connected to **SQL Server (SSMS)**,
providing a secure, role-based platform to manage street children data — replacing
paper-based records entirely.

---

## 📄 Project Report

👉 [Click here to view the full Project Report (PDF)](Docs/Street-Children-Care-System-Report.pdf)

---

## 📌 About

Bangladesh has a large number of street children who lack stable shelter, proper
identification, and consistent healthcare. Organizations such as orphanages, NGOs, and
charitable foundations still rely on paper-based, manual record-keeping — causing data
loss, duplication, missed vaccination schedules, and uncontrolled access to sensitive
records.

The **Street Children Care System** solves this by providing a centralized digital
platform where authorized users can manage all child-related data in one secure
desktop application.

---

## 🛠️ Tech Stack

| Technology | Usage |
|---|---|
| **C# (.NET Framework)** | Core application language |
| **Windows Forms** | Desktop UI framework |
| **SQL Server (SSMS)** | Relational database backend |
| **ADO.NET** | Parameterized query data access |
| **Microsoft Visual Studio 2022** | Development IDE |

---

## ✨ Key Features

- 🔐 **Role-Based Login** — Admin gets full CRUD access; Staff gets view and search access only
- 👦 **Children Management** — Register, update, delete, search, and sort child records
- 👤 **Child Profile View** — Detailed profile page with complete linked vaccination history
- 🏠 **Orphanage Management** — Full CRUD with search and sort functionality
- 🤝 **Foundation Management** — Manage supporting foundations with support type tracking (Food, Clothing, Education, Medical)
- 💉 **Vaccination Tracking** — Track Pending, Completed, and Overdue statuses per child
- 📊 **Admin Dashboard** — Real-time summary counts with instant overdue vaccination alerts
- 👁️ **Staff Dashboard** — View-only access with strict read-only restrictions
- 👥 **User Management** — Admin-only module to create, assign roles, and delete user accounts

---

## 🗄️ Database Structure

5 normalized tables (1NF to 3NF):

| Table | Primary Key | Description |
|---|---|---|
| `Users` | UserID | Login credentials and role assignment |
| `Children` | ChildID | Street children registration records |
| `Orphanages` | OrpID | Orphanage registry with location and contact |
| `Foundations` | FouID | Supporting foundations with type and contact |
| `Vaccinations` | VacID | Vaccination records linked to each child |

**Relationships:**
- Orphanages → Children — One-to-Many
- Foundations → Children — One-to-Many
- Children → Vaccinations — One-to-Many

---

## 📋 System Modules

| Module | Source File | Access Level |
|---|---|---|
| Login | `frmLogin.cs` | Admin and Staff |
| Admin Dashboard | `frmAdminDashboard.cs` | Admin only |
| Staff Dashboard | `frmStaffDashboard.cs` | Staff only |
| Children Management | `frmChildren.cs` | Admin (CRUD) / Staff (View) |
| Child Profile | `frmChildProfile.cs` | Admin (Edit/Delete) / Staff (View) |
| Orphanage Management | `frmOrphanage.cs` | Admin (CRUD) / Staff (View) |
| Foundation Management | `frmFoundation.cs` | Admin (CRUD) / Staff (View) |
| Vaccination Management | `frmVaccination.cs` | Admin (CRUD) / Staff (View) |
| User Management | `frmManageUsers.cs` | Admin only |

---

## 🚀 How to Run

### Prerequisites
- Windows OS
- Microsoft Visual Studio 2022
- SQL Server and SQL Server Management Studio (SSMS)
- .NET Framework

### Setup Steps

**Step 1 — Clone the repository**
```bash
git clone https://github.com/ismmmx/StreetChildrenCareSystem.git
```

**Step 2 — Restore the Database**
- Open SSMS
- Right-click **Databases** → **Restore Database**
- Select **Device** → browse and load `StreetChildrenCareDB.bacpac`
  from the `Database/` folder

**Step 3 — Update Connection String**
- Open `StreetChildrenCareSystem.slnx` in Visual Studio
- In `StreetChildrenCareSystem/Database (SQL folder)/DBHelper.cs`,
  update the connection string with your SQL Server instance name

**Step 4 — Build and Run**
- Press `F5` or click **Start** in Visual Studio

### 🔑 Default Login Credentials

| Role | User ID | Password |
|---|---|---|
| Admin | `admin01` | `admin123` |
| Admin | `admin02` | `admin456` |
| Staff | `staff01` | `staff123` |
| Staff | `staff02` | `staff456` |

---

## 📁 Project Structure

```
StreetChildrenCareSystem/                          ← Repository Root
│
├── 📁 Database/
│   └── StreetChildrenCareDB.bacpac                ← Database backup file
│
├── 📁 Docs/
│   └── Street-Children-Care-System-Report.pdf     ← Full project report
│
├── 📁 StreetChildrenCareSystem/                   ← Solution folder
│   │
│   ├── 📁 StreetChildrenCareSystem/               ← C# Project
│   │   │
│   │   ├── 📁 Database (SQL folder)/
│   │   │   ├── DBHelper.cs
│   │   │   ├── StreetChildrenCareDB.bacpac
│   │   │   └── View_All_Data_Check.sql
│   │   │
│   │   ├── 📁 Forms/
│   │   │   ├── frmAdminDashboard.cs
│   │   │   ├── frmChildProfile.cs
│   │   │   ├── frmChildren.cs
│   │   │   ├── frmFoundation.cs
│   │   │   ├── frmManageUsers.cs
│   │   │   ├── frmOrphanage.cs
│   │   │   ├── frmStaffDashboard.cs
│   │   │   └── frmVaccination.cs
│   │   │
│   │   ├── 📁 Models/
│   │   │   ├── Child.cs
│   │   │   └── User.cs
│   │   │
│   │   ├── 📁 Properties/
│   │   │   ├── AssemblyInfo.cs
│   │   │   ├── Resources.resx
│   │   │   └── Settings.settings
│   │   │
│   │   ├── frmLogin.cs
│   │   ├── App.config
│   │   ├── Program.cs
│   │   └── packages.config
│   │
│   └── StreetChildrenCareSystem.slnx
│
├── .gitignore
└── README.md
```

---

## 👨‍💻 Developer

**Ishmam Mubtasim**  
American International University-Bangladesh (AIUB)  
Department of Computer Science and Engineering, Faculty of Science and Technology  
Course: CSC2210 — Object Oriented Programming 2 | Spring 2025-2026

---

## 📜 License

MIT License

Copyright (c) 2026 Ishmam Mubtasim

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
