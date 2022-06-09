docker build -f "./NoEngine/Dockerfile" -t noengine:latest ./

cd Engine
docker build -f "./Dockerfile" -t engine:latest ./

cd ..