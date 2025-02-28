# Point of Sale OOP Test Task

## Overview

This project implements a **Point of Sale (POS) scanning API** for a grocery market. The solution calculates the total price of items in a shopping cart while considering both **per-unit prices** and **volume discounts** where applicable. The code follows **object-oriented principles** and includes **automated tests** to verify correctness. It is inspired by **Clean Architecture** and utilizes the **Chain of Responsibility** (GoF) design pattern for flexible and maintainable pricing calculations.

## Requirements

The system must:

- Accept an **arbitrary ordering** of scanned products.
- Apply the correct pricing based on **per-unit rates** or **volume discounts**.
- Provide a way to **set pricing**, **scan products**, and **calculate the total price**.
- Not require any **form of persistence**.

### Product Pricing

| Product Code | Pricing                           |
| ------------ | --------------------------------- |
| A            | $1.25 each or 3 for $3.00       |
| B            | $4.25                            |
| C            | $1.00 each or $5 for a six-pack |
| D            | $0.75                            |

## API Usage

The **PointOfSaleTerminal** class provides the following interface:

```csharp
PointOfSaleTerminal terminal = new PointOfSaleTerminal();
terminal.SetPricing(...);
terminal.Scan("A");
terminal.Scan("C");
... // More scans

double result = terminal.CalculateTotal();
```

## Test Cases

The solution must correctly compute total prices for the following test cases:

1. **Scan items in order:** `ABCDABA`   **Expected Total:** `$13.25`
2. **Scan items in order:** `CCCCCCC`   **Expected Total:** `$6.00`
3. **Scan items in order:** `ABCD`   **Expected Total:** `$7.25`

## Running Tests

The project includes **automated tests** to verify correctness. To execute them:

```sh
# Run unit tests
dotnet test
```

## Implementation Notes

- The system allows only **one volume discount per product**.
- It supports dynamic **pricing configuration** via `SetPricing()`.
- The code is structured following **SOLID principles** for maintainability.

## License

This project is provided under the **MIT License**.
