

# Testing

You can build locally
```
$ docker build -t mvcpatients:0.5 .
```

And run passing in your settings
```
$ docker run -e DB_HOST=12.34.56.78 -e DB_NAME=patientsdb -e DB_USER=patientuser -e DB_PASSWORD=SuperSecretPassword1234 -p 8888:8080 mvcpatients:0.5
```

# Kubernetes

You can use the manifest, providing you updated the values

```
$ kubectl create ns patientsmvc
namespace/patientsmvc created

$ kubectl apply -f ./Deployment/manifest.yaml -n patientsmvc
secret/db-secret created
deployment.apps/mvcpatients-deployment created
service/mvcpatients-service created
```

Or Helm if you prefer
```
$ helm install mypatientmvc --create-namespace -n patientsmvc --set env.dbHost=12.34.56.78 --set env.dbName=patientsdb --set env.dbUser=patientuser --set env.dbPassword='myBigComplicatedPasswordHere' ./Deployment/chart/
NAME: mypatientmvc
LAST DEPLOYED: Sat Aug 10 12:25:25 2024
NAMESPACE: patientsmvc
STATUS: deployed
REVISION: 1
TEST SUITE: None
```