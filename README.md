# CFPG Family Tree

![GitHub last commit](https://img.shields.io/github/last-commit/alexrogers823/CfpgFamilyTree)
![GitHub commit activity](https://img.shields.io/github/commit-activity/w/alexrogers823/CfpgFamilyTree)

This is a full-stack application about preserving and updating a family tree. Users of the app can see our family lineage, view biographies of each family member in the tree, see a timeline of important family events, and even view historic documents that are unique to our family history.

### _Technologies Used_
The application is built using PostgreSQL, C#.NET, React.js, and Redux.js. This repository is the backend part of the application (click [here](https://github.com/alexrogers823/family-tree-ui-prototype) for the frontend).

### _Background / Motivation_
The idea for this project was conceived in August 2020. My grandmother was turning 100-years old in December of that year, and I wanted to give her and the family a gift that would be extremely beneficial and long-lasting to commemorate a historic milestone. A family tree had been previously created 10 years prior on a pen and paper, which was put on the wall of my grandmother's basement. Knowing that it needed to be upgraded and digitized, I began designing and building the application.

### _Objective_
The project aims to acheive the following:
- Allow for dynamic expansion and editing of family lineage
- Decentralize responsibility of editing so that each user of the app can make additions and edits
- Include biographical content of each family member to enhance and preserve our family history

---

### _Getting Started_
Tech Requirements:
- [PostgreSQL](https://postgresapp.com/downloads.html)
- [Docker](https://www.docker.com/products/docker-desktop)
- [.NET Core](https://dotnet.microsoft.com/download/dotnet-core)
- [Node.js](https://nodejs.org/en/download/)
- React.js

### _Installation_
1. Clone the repository
    - SSH: `git clone git@github.com:alexrogers823/CfpgFamilyTree.git`
    - HTTPS:  `git clone https://github.com/alexrogers823/CfpgFamilyTree.git`
    - [Download ZIP](https://github.com/alexrogers823/CfpgFamilyTree/archive/master.zip)
2. Have a docker container running (Postgres connection is using a container)
3. Make sure that dotnet 3.1 is installed by running `dotnet build`
4. Change directories into `/src/CfpgFamilyTree` and verify that it works with `dotnet run`
5. (Optional) Change directories into `/test/CfpgFamilyTree.Tests` and run all tests with `dotnet test`