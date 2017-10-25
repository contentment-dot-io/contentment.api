# Contentment API

A simple Open Source API for Content Management.

[![Waffle.io - Columns and their card count](https://badge.waffle.io/contentment-dot-io/contentment.api.svg?columns=all)](http://waffle.io/contentment-dot-io/contentment.api)

[![Join the chat at https://gitter.im/contentment-dot-io/Lobby](https://badges.gitter.im/contentment-dot-io/Lobby.svg)](https://gitter.im/contentment-dot-io/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Contributing

Pull requests are always welcome. Please read the [contributing guidelines](.github/CONTRIBUTING.md).

## Docker

### Build with Docker

```bash
cd ./src/Contentment.Api

docker build -t contentment-api .
```

### Run from Docker

```bash
docker run -it -p 5000:80 contentment-api
```

Navigate to `http://localhost:5000/info/`