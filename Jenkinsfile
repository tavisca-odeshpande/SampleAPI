pipeline {
    agent any
    parameters {
        choice(
            choices: ['BUILD' , 'TEST'],
            description: '',
            name: 'REQUESTED_ACTION')
        string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-odeshpande/SampleAPI', description: 'repository path')
        string(name: 'SOLUTION_PATH', defaultValue: 'SampleAPI.sln', description: 'solution path')
        string(name: 'TEST_PATH', defaultValue: 'ApiTests/ApiTests.csproj', description: 'test path')
    }
    stages {
        stage('Build') {
            when {
                expression { params.REQUESTED_ACTION == 'BUILD' || params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                powershell(script: 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json')
                powershell(script: 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n')
            }
        }
        stage('Test') {
            when {
                expression { params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                powershell(script: 'dotnet test ${TEST_PATH}')
            }
        }
        stage('Publish') 
        {
            steps 
            {
                powershell(script: 'dotnet publish $env:projectToBePublished -c Release -o artifacts')
            }
        }
        stage('Archive')
        {
            steps
            {
                powershell(script: 'compress-archive DemoWebApp/artifacts publish.zip -Update')
                archiveArtifacts artifacts: 'publish.zip'    
            }
        }
    }
}
