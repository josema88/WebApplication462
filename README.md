# .NET Framework 4.62 Web App


## PowerShell Commands to Build and Deploy
This Scripts implementation assumes that the code was already pulled from the repo.

### Stage 1: Build and Publish Artifact

PowerShell Script Draft for Stage 1:
```Powershell
$MainProjectPath = "WebApplication462\WebApplication462.csproj"
$TargetFrameworkVersion = "v4.6.2"
$ProjectName = "WebApplication462"
$PackageVersion = "0.0.1"
$PackageName = $ProjectName+"-v"+$PackageVersion+".zip"
$PublishDirPath = "C:\PublishFolder\"+$ProjectName
$ArtifactSourcePath = $PublishDirPath+"\*"
$ArtifactDestPath  = "C:\Artifacts\"+$PackageName

#Restore Packages
nuget restore

#Build Project
msbuild $MainProjectPath /p:Configuration=Release /p:TargetFrameworkVersion=$TargetFrameworkVersion

#Generate Files to Publish
msbuild $MainProjectPath /p:Configuration=Release /p:TargetFrameworkVersion=$TargetFrameworkVersion /p:DeployOnBuild=true /t:WebPublish /p:WebPublishMethod=FileSystem /p:publishUrl=$PublishDirPath /p:PackageAsSingleFile=false

#Generate Artifact as Zip and send it to Destination
Compress-Archive -Path $ArtifactSourcePath -DestinationPath $ArtifactDestPath
```

### Stage 2: Deploy Artifact

PowerShell Script Draft for Stage 2:
```Powershell
$ProjectName = "WebApplication462"
$PackageVersion = "0.0.1"
$PackageName = $ProjectName+"-v"+$PackageVersion+".zip"
$ArtifactPath  = "C:\Artifacts\"+$PackageName
$DestinationFolderPath = "C:\inetpub\WebApplication462"


#Create a Temporary Folder
New-Item -ItemType Directory -Path "TempFolder"

#Copy Artifacto to the Temporary Folder
Copy-Item -Path $ArtifactPath -Destination "TempFolder"

#Unzip the Artifact from the Temporary folder to the Destination Path
Expand-Archive -Path "TempFolder\$PackageName" -DestinationPath $DestinationFolderPath
```