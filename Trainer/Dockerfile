


FROM microsoft/dotnet:2.1-sdk-alpine AS builder
WORKDIR /
COPY . .
RUN dotnet publish Trainer/Trainer.csproj -o /dockerout/ -c Release

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /dockerout .
ENV ASPNETCORE_URLS http://*:4400
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "Trainer.dll"]

