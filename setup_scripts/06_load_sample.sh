#!/bin/bash
set -x

export PGINST=mypatientsdb
export PASSWD=SuperSecretPassword1234

gcloud sql instances describe $PGINST \
    --format="value(ipAddresses)" > ip_address.txt


PGPASSWORD=$PASSWD psql -h $(cat ip_address.txt | cut -d';' -f1 | cut -d':' -f2 | cut -d',' -f1 | sed 's/"//g' | sed "s/'//g" | tr -d ' ' ) -U patientuser -d patientsdb -f ./06_load_sample.sql

