#!/usr/bin/env bash

set -e

docker run \
  -e BUILD_NAME \
  -e BUILD_TARGET \
  -w /project/ \
  -v $(pwd):/project/ \
  $IMAGE_NAME \
  /bin/bash -c "/project/ci/build.sh"
