pipeline {
    // agent any
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
        }
    }
    // environment {
    //     EC2_USER = credentials('EC2_USER')
    //     EC2_HOST = credentials('EC2_HOST')
    //     EC2_SSH_KEY = credentials('EC2_SSH_KEY')
    // }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o publish'
            }
        }

        // stage('Deploy to EC2') {
        //     steps {
        //         sh '''
        //         mkdir -p ~/.ssh
        //         echo "$EC2_SSH_KEY" > ~/.ssh/id_rsa
        //         chmod 600 ~/.ssh/id_rsa
        //         ssh-keyscan -H $EC2_HOST >> ~/.ssh/known_hosts

        //         rsync -avz publish/ $EC2_USER@$EC2_HOST:/home/ec2-user/chasrpexample/

        //         ssh $EC2_USER@$EC2_HOST "sudo systemctl restart notesapi"
        //         '''
        //     }
        // }
    }
} 
