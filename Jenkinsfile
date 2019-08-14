pipeline {
    agent any
    parameters {
        string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-odeshpande/SampleAPI', description: 'repository path')
        string(name: 'SOLUTION_PATH', defaultValue: 'SampleAPI.sln', description: 'solution path')
        string(name: 'TEST_PATH', defaultValue: 'ApiTests/ApiTests.csproj', description: 'test path')
    }
    stages {
        stage('Build') {
            steps {
                sh '''
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json 
                    dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n
                '''
            }
        }
        stage('Test') {
            steps {
                sh'dotnet test ${TEST_PATH}'
            }
        }
    }
}
