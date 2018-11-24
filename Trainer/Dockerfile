# # FROM microsoft/dotnet:2.1-sdk AS build
# # WORKDIR /app

# # # copy csproj and restore as distinct layers
# # COPY *.sln .
# # COPY Shared.Core/*.csproj ./Shared.Core/
# # COPY Trainer.EF/*.csproj ./Trainer.EF/
# # COPY Authentication/*.csproj ./Authentication/
# # COPY Articles.Core/*.csproj ./Articles.Core/
# # COPY AttachmentsManager/*.csproj ./AttachmentsManager/
# # COPY Lookups.Core/*.csproj ./Lookups.Core/
# # COPY MailProvider.Core/*.csproj ./MailProvider.Core/
# # COPY Products.Categories.Core/*.csproj ./Products.Categories.Core/
# # COPY Products.SubCategories.Core/*.csproj ./Products.SubCategories.Core/
# # COPY test.core/*.csproj ./test.core/
# # COPY Rating.core/*.csproj ./Rating.core/
# # COPY Trainer/*.csproj ./Trainer/
# # RUN dotnet restore

# # # copy everything else and build app
# # COPY Trainer/. ./Trainer/
# # COPY Articles.Core/. ./Articles.Core/
# # COPY AttachmentsManager/. ./AttachmentsManager/
# # COPY Authentication/. ./Authentication/
# # COPY Lookups.Core/. ./Lookups.Core/
# # COPY MailProvider.Core/. ./MailProvider.Core/
# # COPY Products.Categories.Core/. ./Products.Categories.Core/
# # COPY Products.SubCategories.Core/. ./Products.SubCategories.Core/
# # COPY Shared.Core/. ./Shared.Core/
# # COPY test.core/. ./test.core/
# # COPY Rating.core/. ./Rating.core/

# # COPY Trainer.EF/. ./Trainer.EF/

# # WORKDIR /app/Trainer
# # RUN dotnet publish -c Release -o ./out
# # COPY Trainer/out ./out

# # FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
# # WORKDIR /app
# # COPY --from=build /app/Trainer/out ./
# # ENTRYPOINT ["dotnet", "Trainre.dll"]

# # # FROM microsoft/dotnet:2.1-sdk
# # # COPY . /app
# # # WORKDIR /app
# # # RUN ["dotnet", "restore", "Trainer"]
# # # RUN ["dotnet", "build", "Trainer"]
# # # EXPOSE 80/tcp
# # # FROM microsoft/dotnet:2.1.0-aspnetcore-runtime 
# # # WORKDIR /app
# # # COPY app .
# # # RUN ["dotnet", "restore", "Trainer"]
# # # RUN ["dotnet", "build", "Trainer"]
# # # # EXPOSE 80/tcp
# # FROM microsoft/dotnet:2.1-runtime
# # WORKDIR /app
# # COPY ./Trainer/out ./
# # ENTRYPOINT ["dotnet", "Trainer.dll"]


FROM microsoft/dotnet:2.1-sdk-alpine AS builder
WORKDIR /
COPY . .
RUN dotnet publish Trainer/Trainer.csproj -o /dockerout/ -c Release
# RUN chmod +x ./entrypoint.sh
# CMD /bin/bash ./entrypoint.sh


FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app


COPY --from=builder /dockerout .
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "Trainer.dll"]


# FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
# WORKDIR /app
# EXPOSE 59518
# EXPOSE 44364

# FROM microsoft/dotnet:2.1-sdk AS build
# WORKDIR /src
# #COPY Trainer/Trainer.csproj Trainer/
# COPY . .
# RUN dotnet restore Trainer/Trainer.csproj
# COPY . .
# WORKDIR /src/Trainer
# RUN dotnet build Trainer.csproj -c Release -o /app

# FROM build AS publish
# RUN dotnet publish Trainer.csproj -c Release -o /app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "Trainer.dll"]

