# CodeChecker [![Build Status](https://travis-ci.org/KTU-BBD/Web-App.svg?branch=master)](https://travis-ci.org/KTU-BBD/Web-App)

ASP.NET C# MVC5 project.

Requirements to run this project:
  - Bower
  - Npm
  - Ruby (for SASS)

Firstly, you need to download required dependencies for this website. You can achieve this by typing:

```sh
npm install
bower install
```

Also ruby is required for this project. Ruby is required for sass compilation. To download sass type:
```sh
gem install sass
```


To concat dependencies, copy fonts to required folders type:
```sh
grunt init
```

To start watching sass files type:
```sh
grunt watch
```