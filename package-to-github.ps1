# Package as a Release build
dotnet build -c Release

# Go to the folder where the nuGet.config file is located
cd path-to-file

# Run the push command from the folder where the nuGet.config file is
dotnet nuget push "package-path" --source "github"