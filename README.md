# MyTraceTrawler

MyTraceTrawler is a command-line application that performs vendor-specific operations to trawl product and brand data from various vendors (Coles, Woolworths, Costco) and saves the collected information to a database.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Features
- Trawl product and brand data from Coles, Woolworths, and Costco.
- Save the collected data to a SQL Server database.
- Command-line interface for specifying vendor operations.
- Handles batch processing for large sets of data.
- Provides detailed logging of the trawling process.

## Installation
1. **Clone the repository:**
    ```sh
    git clone https://github.com/yourusername/MyTraceTrawler.git
    cd MyTraceTrawler
    ```

2. **Restore dependencies:**
    ```sh
    dotnet restore
    ```

3. **Build the project:**
    ```sh
    dotnet build
    ```

## Usage
Run the application with the following command:
```sh
dotnet run -- -vendor <vendor>
```
Replace `<vendor>` with one of the following options:

- `Coles`
- `Costco`
- `Woolworths`

Example:

```sh
dotnet run -- -vendor Coles
```
If no vendor is specified, the application will prompt you to provide a vendor.

## Configuration

Set the SQL connection string as an environment variable:

```sh
export SQL_CONNECTION_STRING="your_sql_connection_string"
```
## Project Structure

- `Program.cs`: Main entry point of the application. Handles command-line argument parsing and vendor-specific logic.
- `Trawlers/ColesTrawler.cs`: Contains methods for trawling Coles product and brand data.
- `Trawlers/CostcoTrawler.cs`: Contains methods for trawling Costco product and brand data.
- `Trawlers/WoolworthsTrawler.cs`: Contains methods for trawling Woolworths product data.
- `MyTraceLib/Services`: Contains services for database operations and API requests.
- `MyTraceLib/Tables`: Contains entity classes representing the database tables.

## Dependencies

- .NET 8.0
- Microsoft.Data.SqlClient 5.2.1
- Microsoft.EntityFrameworkCore 8.0.6
- Microsoft.EntityFrameworkCore.SqlServer 8.0.6
- Microsoft.EntityFrameworkCore.Tools 8.0.6
- Newtonsoft.Json 13.0.3

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a Pull Request.

### License
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


### Contact
For more information, please contact braydennepean@gmail.com
