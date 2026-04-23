# TheMissChat  
A simple, elegant and vintage‑styled real‑time chat platform built with ASP.NET Core MVC and SignalR.

---

## 📖 Overview

TheMissChat is a lightweight chat application where users can register, log in, join chat rooms and exchange messages in real time.  
The interface is designed in a **vintage “old book” style**, giving the platform a unique and atmospheric look.

The project intentionally **does not include admin roles or admin panels** — it is a clean, minimal chat experience.

---

## ✨ Features

- 🧑‍💻 User Registration & Login (Session‑based)
- 💬 Real‑time messaging using SignalR
- 🏛️ Multiple chat rooms
- 📜 Vintage UI design (old paper, serif fonts, warm colors)
- 🗂️ Entity Framework Core database
- 🚪 Logout functionality
- 🔒 No admin roles, no admin logic, no role-based permissions

---

## 🏗️ Technologies Used

- **ASP.NET Core MVC**
- **SignalR** (real-time communication)
- **Entity Framework Core**
- **SQL Server LocalDB**
- **Bootstrap (lightly used)**
- **Custom CSS for vintage theme**

---

## 📁 Project Structure
TheMissChat/
│
├── Controllers/
│   ├── AccountController.cs
│   └── ChatController.cs
│
├── Hubs/
│   └── ChatHub.cs
│
├── Models/
│   ├── User.cs
│   ├── Message.cs
│   └── ChatRoom.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── Chat/
│   │   ├── Index.cshtml
│   │   └── Room.cshtml
│   └── Shared/
│       └── _Layout.cshtml
│
└── wwwroot/
├── css/
├── js/
└── lib/


