#!/bin/bash

echo "Hello World !"


# 离线激活Unity
mkdir -p /root/.local/share/unity3d/Unity
touch /root/.local/share/unity3d/Unity/Unity_lic.ulf
echo "${PLUGIN_UNITY_LICENSE}" > /root/.local/share/unity3d/Unity/Unity_lic.ulf

echo "=========================================================="

# cat /root/.local/share/unity3d/Unity/Unity_lic.ulf

# cp /root/.local/share/unity3d/Unity/Unity_lic.ulf /data/


echo "=========================================================="

mkdir /cache

${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' /Unity/Editor/Unity} \
 -batchmode -nographics -quit -projectPath /drone/src/UnityTest -logFile /dev/stdout -executeMethod Test.BuildTest

UNITY_EXIT_CODE=$?

if [ $UNITY_EXIT_CODE -eq 0 ]; then
  echo "succeeded, no failures occurred";
else
  echo "Unexpected exit code $UNITY_EXIT_CODE";
  exit 1
fi

ls /cache
