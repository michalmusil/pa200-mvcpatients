

# Testing

You can build locally
```
$ docker build -t mvcpatients:0.5 .
```

And run passing in your settings
```
$ docker run -e DB_HOST=12.34.56.78 -e DB_NAME=patientsdb -e DB_USER=patientuser -e DB_PASSWORD=SuperSecretPassword1234 -p 8888:8080 mvcpatients:0.5
```
