#!/bin/bash
set -x

export PASSWD=c7f21efbb1307854dc22a5a680636bece4d6a475
export PGINST=mypatientsdb

gcloud sql instances describe $PGINST \
    --format="value(ipAddresses)" > ip_address.txt

PGPASSWORD=$PASSWD psql -h $(cat ip_address.txt | cut -d';' -f1 | cut -d':' -f2 | cut -d',' -f1 | sed 's/"//g' | sed "s/'//g" | tr -d ' ' ) -U postgres -d postgres -f ./02_create_db_user.sql

