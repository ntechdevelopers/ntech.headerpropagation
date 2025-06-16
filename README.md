# Ntech.HeaderPropagation

This project demonstrates header propagation in a .NET Core application. It includes a main application (`Ntech.HeaderPropagation`) and an external API (`Ntech.ExternalAPI`) to showcase how headers can be propagated between services.

## Project Structure

- `Ntech.HeaderPropagation/Ntech.HeaderPropagation`: The main application responsible for propagating headers.
- `Ntech.HeaderPropagation/Ntech.ExternalAPI`: An external API that receives and processes the propagated headers.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Build and Run

1. Navigate to the solution directory:

   ```bash
   cd Ntech.HeaderPropagation
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```

4. Run the applications:

   To run `Ntech.HeaderPropagation`:
   ```bash
   cd Ntech.HeaderPropagation/Ntech.HeaderPropagation
   dotnet run
   ```

   To run `Ntech.ExternalAPI` (in a separate terminal):
   ```bash
   cd Ntech.HeaderPropagation/Ntech.ExternalAPI
   dotnet run
   ```

## Usage

Once both applications are running, you can interact with them. The `Ntech.HeaderPropagation` application will forward requests (and propagate headers) to the `Ntech.ExternalAPI`.

Further details on specific API endpoints and header propagation logic can be found by examining the `Controllers` and `Startup.cs` files in each project. 