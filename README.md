# Controle de Medicamentos

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Detalhes

Com a necessidade de controlar os estoques das farmácias dos postos de saúde de Lages, foi proposto pelo
secretário da saúde João do Nascimento, a criação de um sistema simples para a gestão do estoque de remédios
dos postos de saúde de Lages, para assim atender melhor a população nos bairros.

Eles desejam otimizar o controle de estoque das farmácias para facilitar e agilizar o processo de distribuição de
remédios aos pacientes. Os postos utilizam formulários de papel para armazenar as informações das quantidades
de remédios disponíveis nos estoques.

Atualmente, os pacientes requisitam um medicamento e ao fazer a requisição o funcionário do posto verifica a
disponibilidade do medicamento no sistema e caso o mesmo esteja disponível o atendente dá baixa no sistema
(atualiza a quantidade) e entrega o medicamento ao paciente que já esteja cadastrado.

---
## Funcionalidades

### 1. Controle de Medicamentos

- **Registrar Medicamento:** O registro de um medicamento irá ser formado por: nome, descrição e quantidade do estoque. Caso
o mesmo já esteja cadastrado, é atualizado a quantidade.
- **Visualizar Medicamentos:** Exibe uma lista exibindo detalhes de todos os medicamentos registrados, **também deverá exibir quais medicamentos estão em falta** (<20 unidades).
- **Editar Medicamentos:** Oferece a possibilidade de modificar informações de um medicamento existente.
- **Excluir Medicamentos:** Permite remover um medicamento do sistema, atualizando a lista de medicamentos registrados.

### 2. Controle de Paciente

- **Registrar Paciente:** O paciente deverá ser registrado com as seguintes informações: nome, telefone e cartão do SUS.
- **Visualizar Pacientes:** Exibe uma lista exibindo detalhes de todos os medicamentos registrados.
- **Editar Pacientes:** Oferece a possibilidade de modificar informações de um paciente cadastrado.
- **Excluir Pacientes:** Permite remover um registro de paciente do sistema.

### 3. Controle de Requisições

- **Registrar Requisição:** O paciente poderá registrar uma nova requisição que incluirá: data da requisição, dados do paciente, dados do medicamento e a quantidade do medicamento requisitada.
- **Visualizar Requisições:** Exibe uma lista exibindo detalhes de todas as requisições registradas.
- **Visualizar Requisições de um Paciente:** Permite visualizar uma lista de requisições realizadas por um paciente específico.

**Ao fazer uma requisição de medicamento, será necessário verificar se a quantidade do mesmo está disponível no estoque. Também será necessário subtrair esta quantidade do registro do estoque.**

---
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/psergioPadilha/controle-medicamentos-2024.git
```

#### Navegue até a pasta raiz da solução
```
cd controle-medicamentos-2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd ControleMedicamentos.ConsoleApp
```

#### Execute o projeto
```
dotnet run
```
