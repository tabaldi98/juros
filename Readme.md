# Api Taxa e Calculo de Juros
_Instruções para execução pelo docker_

Com o docker inicializado, basta navegar até a pasta da solução através do powershell e executar o seguinte comando:
```sh
docker-compose up
```

A Api-taxa-juros estará disponível no seguinte endereço: http://localhost:8081
A Api-calculo-juros estará disponível no seguinte endereço: http://localhost:8082

A Api-calculo-juros faz a comunicação com a Api-taxa-juros. O endereço para comunicação está pré-configurado para comunicação através do docker. Caso seja nescessário alterar, basta encontrar a chave `EnderecoTaxaJurosApi` no appsettings da aplicação.