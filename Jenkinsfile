pipeline {
    agent any
    parameters {
        choice(
            choices: ['BUILD' , 'TEST'],
            description: 'Select from build choices',
            name: 'REQUESTED_ACTION')
        string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-odeshpande/SampleAPI/tree/develop', description: 'repository path')
        string(name: 'SOLUTION_PATH', defaultValue: 'SampleAPI.sln', description: 'solution path')
        string(name: 'TEST_PATH', defaultValue: 'ApiTests/ApiTests.csproj', description: 'test path')

        string(name: 'DOCKER_HUB_USERNAME', defaultValue: 'omkar1997')
        string(name: 'DOCKER_HUB_CREDENTIALS_ID', defaultValue: 'docker-hub-credentials')

    }
    environment
    {
        projectToBePublished = 'SampleAPI'
    }
    stages {
        stage('Build') {
            /*agent {
                docker { image 'dot-net-build-env' }
            }*/
            when {
                expression { params.REQUESTED_ACTION == 'BUILD' || params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                powershell(script: 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json')
                powershell(script: 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n')
            }
        }
        stage('Test') {
            /*agent {
                docker { image 'dot-net-test-env' }
            }*/
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
                powershell(script: 'compress-archive SampleAPI/artifacts publish.zip -Update')
                archiveArtifacts artifacts: 'publish.zip'    
            }
        }
        stage('Set-up for docker CustomImage creation')
        {
            steps
            {
                powershell "mv Dockerfile ${env.APPLICATION_NAME}/${env.artifactsDirectory}"
            }
        }
        stage('Build Custom Docker Image')
        {
            steps 
            {
                script 
                {
                    dir("${env.APPLICATION_NAME}/${env.artifactsDirectory}") 
                    {
                        powershell "docker build -t ${env.DOCKER_HUB_USERNAME}/${env.DOCKER_IMAGE_NAME}:${env.DOCKER_IMAGE_TAG} --build-arg APPLICATION_NAME_TO_BE_HOSTED=${env.APPLICATION_NAME} ."
                    }
                }
            }
        }
        stage('Push Docker CustomImage to DockerIO registry') 
        {
            steps {
                script {
                    docker.withRegistry('https://www.docker.io/', "${env.DOCKER_HUB_CREDENTIALS_ID}") 
                    {
                        powershell "docker push ${env.DOCKER_HUB_USERNAME}/${env.DOCKER_IMAGE_NAME}:${env.DOCKER_IMAGE_TAG}"   
                    }
                }
            }
        }
    }
}
