# .Net Core-GraphQL-Example
 EntityFramework Code First, GraphQL Application Example
 
# Important
 You can automatically create the database with migration because of code first 

# Required Installations

İf you want to use for own project, you should install the following libraries

-> dotnet add package HotChocolate.AspNetCore
#
-> dotnet add package HotChocolate.Data.EntityFramework
#
-> dotnet add package Microsoft.EntityframeworkCore.Design
#
-> dotnet add package Microsoft.EntityframeworkCore.SqlServer
#
-> dotnet add package GraphQL.Server.Ui.Voyager 



# After Dowloading this project, you can call the following url

http://localhost:5000/graphql 

# GraphQL post query example 

mutation{
  addPlatform(input:{name: "OSX"})
  {
    platform
    {
      id
    }
  }
}

mutation{
  addCommand(input:{ howTo: "OSX" platformId:1 commandLine : "deneme-run"})
  {
    command{id}
  }
} 
