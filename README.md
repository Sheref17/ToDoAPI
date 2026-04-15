# 📝 ToDo Task API

A simple and scalable RESTful API for managing ToDo tasks built with **ASP.NET Core**, using **Clean Architecture principles**, **AutoMapper**, and **Entity Framework Core**.



## 📦 Features

* ✅ Create Task
* 📄 Get All Tasks
* 🔍 Get Task By Id
* ✏️ Update Task
* 🗑️ Delete Task
* 🛡️ Validation handling
* ⚡ Clean layered architecture

---

## 🏗️ Architecture

The project follows a layered structure:

```
- Presentation Layer (Controllers)
- Service Layer (Business Logic)
- Domain Layer (Entities & Interfaces)
- Persistence Layer (EF Core / Database)
```



## 🧠 Notes


* `DateTime` values must be in valid format (`yyyy-MM-dd`)

* **Status enum values:**

  * `Pending`
  * `InProgress`
  * `Completed`

* **Priority enum values:**

  * `Low`
  * `Medium`
  * `High`



---

## 🛠️ Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* AutoMapper
* SQL Server
* Swagger (Swashbuckle)

---

## 📈 Future Improvements

* 🔐 Authentication & Authorization (JWT)
* 📊 Pagination & Filtering
* 🧾 Logging & Monitoring
* ⚡ Caching


---



## ⭐ Contribute

Feel free to fork the repo and submit pull requests!
http://todotask.runasp.net/swagger/index.html
---
