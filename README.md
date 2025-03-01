# C# Design Patterns Implementation

This repository contains implementations of various **C# Design Patterns**, including:

- ✅ **Factory Pattern** (Notification System)
- ✅ **Fluent Builder Pattern** (SQL Query Generator)
- ✅ **Observer Pattern** (Stock Price Alert System)

Each pattern is implemented in **C# 8.0** and demonstrates real-world scenarios.

---

## 📌 1. Notification System (Factory Pattern)

A flexible **notification system** that supports multiple types of notifications (Email, SMS, Push).  
This implementation follows the **Factory Pattern**, making it easy to extend with new notification types.

### 🛠 Implementation

```csharp
INotification notification = NotificationFactory.CreateNotification("email");
notification.Send("Hello, this is a test email!");
📌 Class Structure:
INotification (Interface) – Defines the contract for all notifications.
EmailNotification, SMSNotification, PushNotification (Concrete Classes) – Implement the interface.
NotificationFactory (Factory Class) – Creates instances dynamically.
📌 2. SQL Query Builder (Fluent Builder Pattern)
A Fluent Builder for dynamically generating SQL queries, ensuring readability and preventing SQL injection.

🛠 Implementation
csharp
Copy
Edit
string query = new SqlQueryBuilder()
    .Select("*")
    .From("Users")
    .Where("Age > 18")
    .OrderBy("Name")
    .Build();

Console.WriteLine(query);
📌 Class Structure:
SqlQueryBuilder (Builder Class) – Provides methods to construct SQL queries using a fluent API.
📌 3. Stock Price Alert System (Observer Pattern)
An Observer Pattern implementation where investors (observers) receive updates when a stock price changes.

🛠 Implementation
csharp
Copy
Edit
Stock appleStock = new Stock("AAPL", 150.00);

Investor investor1 = new Investor("Alice");
Investor investor2 = new Investor("Bob");

appleStock.Attach(investor1);
appleStock.Attach(investor2);

appleStock.SetPrice(155.50); // Notifies all investors
📌 Class Structure:
IInvestor (Observer Interface) – Defines the update method.
Investor (Concrete Observer) – Implements the update logic.
Stock (Subject) – Maintains investor list and notifies them when the price changes.
🚀 How to Run
Clone the repository:
sh
Copy
Edit
git clone https://github.com/yourusername/design-patterns-csharp.git
Open in Visual Studio or VS Code.
Build and Run the desired program.
