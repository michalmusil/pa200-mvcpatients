#!/bin/bash
set -x

export PASSWD=c7f21efbb1307854dc22a5a680636bece4d6a475
export PGINST=mypatientsdb

# Create Database
gcloud sql instances create $PGINST \
    --database-version=POSTGRES_14 \
    --region=us-central1 \
    --tier=db-f1-micro \
    --activation-policy=ALWAYS

# set "postgres" user password
gcloud sql users set-password postgres \
    --instance=$PGINST \
    --password=$PASSWD

