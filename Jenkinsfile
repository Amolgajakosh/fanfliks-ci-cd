pipeline {
    agent any

    environment {
        IMAGE_NAME = "your-dockerhub-username/fanfliks-api"
        BRANCH = "main" // change as needed
        DOCKER_TAG = "${BUILD_NUMBER}"
    }

    stages {
        stage('Clone Repo') {
            steps {
                git branch: "${BRANCH}", url: 'https://github.com/your-username/your-fanfliks-repo.git'
            }
        }

        stage('Build and Publish .NET App') {
            steps {
                dir('Fanfliks.API') {
                    sh 'dotnet publish -c Release'
                }
            }
        }

        stage('Prepare Docker Context') {
            steps {
                sh '''
                cp -r Fanfliks.API/bin/Release/net8.0/publish/* docker/
                '''
            }
        }

        stage('Docker Build & Push') {
            steps {
                dir('docker') {
                    sh """
                    docker build -t ${IMAGE_NAME}:${DOCKER_TAG} .
                    docker push ${IMAGE_NAME}:${DOCKER_TAG}
                    """
                }
            }
        }

        stage('Update Kubernetes Deployment') {
            steps {
                sh """
                kubectl set image deployment/fanfliks-api fanfliks-api=${IMAGE_NAME}:${DOCKER_TAG}
                """
            }
        }
    }
}
