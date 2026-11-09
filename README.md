# Lab 2: Bicycle Rental & Mushroom Identifier

C# Windows Forms application (.NET 8) following the whiteboard design:

Login -> Choose -> Bicycle / Mushroom (each with Logout)

## Features
- **Login:** blocks empty fields and only accepts the admin account (username `Massa`, password `123@`).
- **Choose:** menu with Bicycle and Mushroom buttons.
- **Bicycle:** start/end hour validation (`int.TryParse`, ranges 0-23 / 1-24), hour-by-hour `while` loop for the rate, result in the **Total** textbox and a **MessageBox**.
- **Mushroom:** Yes/No questions with RadioButtons in GroupBoxes, decision tree result shown in a MessageBox, answers cleared afterwards.
- **Logout / Back** buttons on both activity forms.

## Run
1. Install Visual Studio 2022+ with the ".NET desktop development" workload (or the .NET 8 SDK).
2. Open `Lab2BicycleMushroom.csproj`.
3. Press F5.

Or in a terminal (Windows): `dotnet run`

## Screenshots
Add your screenshots here (Login, Choose, Bicycle, Mushroom).

*Student name / ID: ______*
