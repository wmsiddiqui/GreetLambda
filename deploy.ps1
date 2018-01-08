if (Test-Path "./deploy") {
	Remove-Item -path "./deploy" -recurse
}

New-Item -Path ./deploy/bin -ItemType Directory -Force
New-Item -Path ./deploy/compressed -ItemType Directory -Force
dotnet publish "./GreetLambda/GreetLambda.csproj" --output "../deploy/bin"

[Reflection.Assembly]::LoadWithPartialName( "System.IO.Compression.FileSystem" )
[System.IO.Compression.ZipFile]::CreateFromDirectory("./deploy/bin", "./deploy/compressed/package.zip")

aws s3 cp ./deploy/compressed/package.zip s3://greet-lambda/greet.zip

aws --region us-east-1 cloudformation deploy --template-file "./Stack.json" --stack-name GreetStack

Read-Host -Prompt "Press Enter to exit"