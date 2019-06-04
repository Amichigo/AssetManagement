#!/bin/bash

SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
ROOT_PROJECT=$(realpath "$SCRIPTPATH/../..")

function refreshSwagger() {
    "$ROOT_PROJECT/angular/node_modules/.bin/nswag" run "$ROOT_PROJECT/angular/nswag/service.config.nswag"
}

function setupAngular() {
    # dont touch node_moudles once install the first time
    if [[ ! -d "$ROOT_PROJECT/angular/node_modules" ]]; then
        echo 'angular/node_moudles not exist. run npm install'
        cd "$ROOT_PROJECT/angular"
        npm install
    fi

    npm start-server
}

function main() {
    refreshSwagger
    setupAngular
}

main