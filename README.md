# 🚗 CarWash - Gestão de Estética Automotiva Multiunidade

O **CarWash** é um sistema ERP web de gestão interna projetado para profissionalizar estabelecimentos de estética automotiva. Ele substitui controles manuais por uma plataforma centralizada que gerencia desde a agenda inteligente até a capacidade operacional de múltiplas filiais.

---

## 🎯 Problemas que Resolvemos
O sistema foi projetado para atacar diretamente as seguintes dores de negócio:
* **Desorganização:** Elimina agendamentos via WhatsApp ou papel.
* **Ociosidade:** Otimiza a agenda com suporte a atendimentos simultâneos.
* **Conflitos de Frota:** Bloqueia o agendamento do mesmo veículo em horários sobrepostos, mesmo entre filiais diferentes.
* **Gestão de Capacidade:** Ajuste dinâmico de células de lavagem ativas (1 a 100 por unidade).

---

## ✨ Funcionalidades do MVP

### 📅 Agenda e Operação
* **Agendamento Inteligente:** Exige seleção de filial e valida conflitos globais de veículos.
* **Gestão Multiunidade:** Controle individual de capacidade e células por filial.
* **Responsáveis Vinculados:** Permite que pessoas autorizadas (além do titular) levem o veículo para atendimento.

### 👥 Cadastros e Dados
* **Clientes e Veículos:** Vínculo obrigatório entre dono e carro, com validação de placa única no sistema.
* **Catálogo de Serviços:** Definição de preços e tempos de duração estimada para cada tipo de lavagem.
* **Observações Logísticas:** Registro de estado do veículo e cuidados específicos por atendimento.

### 📊 Gestão e Segurança
* **Dashboard:** Indicadores de ocupação, faturamento estimado e total de atendimentos.
* **Segurança:** Autenticação via login/senha, sessões protegidas e tráfego HTTPS.
* **Temas:** Suporte nativo a Modo Claro e Modo Escuro (Dark Mode).

---

## 🛠️ Stack Tecnológica

| Camada | Tecnologia | Justificativa |
|---|---|---|
| **Frontend** | React | Alta performance e componentização para UI responsiva. |
| **Backend** | .NET (C#) | Robustez para regras de negócio e modelagem POO. |
| **Banco de Dados** | PostgreSQL | Integridade transacional e consistência de dados (ACID). |

---

## 📂 Estrutura de Documentação Técnica
O projeto é guiado por 4 documentos fundamentais disponíveis na pasta `/docs`:
1. **DVP-E:** Visão do Produto, Escopo e priorização MoSCoW.
2. **DVS:** Estudo de viabilidade técnica, econômica e operacional.
3. **DRP:** Requisitos funcionais detalhados e critérios de aceitação.
4. **DAT:** Arquitetura lógica, modelo de dados e infraestrutura.

---

## 🚀 Como instalar

```bash
# Clone este repositório
$ git clone https://github.com/MatheusMoreira08/CarWash.git

# Instale as dependências do Frontend (React)
$ cd frontend && npm install

# Execute a aplicação em modo dev
$ npm run dev
```

---
