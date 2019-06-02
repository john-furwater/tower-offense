#!/usr/bin/env sh

set -x

export UNITY_EXECUTABLE=${UNITY_EXECUTABLE:-"/Applications/Unity/Hub/Editor/2019.1.4f1/Unity.app/Contents/MacOS/Unity"}
export BUILD_NAME=${BUILD_NAME:-"TowerOffenseLocal"}

BUILD_TARGET=StandaloneLinux64 ./ci/build.sh
BUILD_TARGET=StandaloneOSX ./ci/build.sh
BUILD_TARGET=StandaloneWindows64 ./ci/build.sh
BUILD_TARGET=WebGL ./ci/build.sh
