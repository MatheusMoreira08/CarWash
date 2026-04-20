# Documento de Visão do Produto e Escopo (DVP-E)

**Projeto:** CarWash\
**Versão:** 2.4\
**Autor:** Antonio Neto\
**Data:** 23/03/2026

---

## Histórico de Alterações

| Versão | Data       | Autor        | Descrição                                          |
| ------ | ---------- | ------------ | -------------------------------------------------- |
| 1.0    | 08/03/2026 | Antonio Neto | Versão inicial do documento                        |
| 2.0    | 19/03/2026 | Antonio Neto | Revisão geral: detalhamento, correções e expansões |
| 2.1    | 20/03/2026 | Antonio Neto | Inclusão de filiais, células dinâmicas e responsáveis |
| 2.2    | 23/03/2026 | Antonio Neto | Ajuste do critério S5 para alinhamento ao escopo Should Have de confirmações automáticas |
| 2.3    | 23/03/2026 | Antonio Neto | Detalhamento do fluxo de responsável no agendamento e reforço das validações críticas multiunidade |
| 2.4    | 23/03/2026 | Antonio Neto | Ajuste textual de conflito global na mesma ou em outra filial e reforço de cobertura de testes de negócio |

---

## 1. Introdução

### 1.1 Propósito do Documento

Este Documento de Visão do Produto e Escopo (DVP-E) tem como finalidade estabelecer um entendimento comum entre todas as partes interessadas sobre o que o sistema CarWash é, qual problema ele resolve e quais são os limites da sua primeira versão.

Ele serve como referência base para a tomada de decisões durante o desenvolvimento e como ponto de partida para documentos técnicos subsequentes, como o Documento de Requisitos do Produto (DRP).

---

### 1.2 Escopo do Documento

Este documento cobre:

- A descrição do problema de negócio e seu contexto operacional;
- A visão e os objetivos estratégicos do produto;
- A identificação de stakeholders, usuários e seus perfis;
- O escopo funcional do sistema, com priorização;
- Premissas, restrições, critérios de sucesso e riscos do projeto.

Este documento **não** cobre detalhes técnicos de implementação, arquitetura de software ou especificações de interface, que serão tratados no DRP.

---

### 1.3 Definições, Acrônimos e Abreviações

| Termo                      | Definição                                                                                                     |
| -------------------------- | ------------------------------------------------------------------------------------------------------------- |
| **CarWash**                | Nome do sistema de gestão desenvolvido neste projeto                                                          |
| **DVP-E**                  | Documento de Visão do Produto e Escopo                                                                        |
| **DRP**                    | Documento de Requisitos do Produto                                                                            |
| **API**                    | Application Programming Interface — interface de comunicação entre sistemas                                   |
| **ERP**                    | Enterprise Resource Planning — sistema de gestão empresarial integrado                                        |
| **Estética automotiva**    | Segmento de serviços especializados em lavagem, polimento, higienização e cuidados visuais de veículos        |
| **Dashboard**              | Painel visual com indicadores e métricas do negócio                                                           |
| **Cliente recorrente**     | Cliente que utiliza os serviços do estabelecimento com frequência regular                                     |
| **Catálogo de serviços**   | Lista configurável dos tipos de serviço oferecidos pelo estabelecimento                                       |
| **Observações logísticas** | Anotações sobre estado do veículo, cuidados específicos e preferências do cliente vinculadas a um agendamento |
| **MVP**                    | Minimum Viable Product — versão mínima viável do produto                                                      |
| **MoSCoW**                 | Método de priorização: Must, Should, Could, Won't                                                             |

---

### 1.4 Visão Geral do Documento

- **Seção 1** — Introdução: propósito, escopo e definições
- **Seção 2** — Descrição do Problema: contexto, problemas e impactos
- **Seção 3** — Visão do Produto: descrição geral, objetivos e benefícios
- **Seção 4** — Stakeholders e Usuários: partes interessadas, perfis e responsabilidades
- **Seção 5** — Escopo do Produto: funcionalidades, priorização e limites
- **Seção 6** — Premissas e Restrições
- **Seção 7** — Critérios de Sucesso
- **Seção 8** — Riscos do Projeto

---

## 2. Descrição do Problema

### 2.1 Contexto do Negócio

O CarWash é destinado a estabelecimentos de estética automotiva de pequeno e médio porte que atualmente operam com processos manuais ou semi-estruturados. Esses negócios tipicamente gerenciam seus agendamentos por meio de cadernos, aplicativos de mensagens (como WhatsApp) ou planilhas pessoais, sem um sistema centralizado.

O proprietário acumula funções de atendimento, operação e gestão, o que dificulta o controle sobre a agenda, o histórico dos clientes e a previsibilidade financeira do negócio.

---

### 2.2 Problemas Identificados

| #   | Problema                                         | Descrição                                                                                                                                                   |
| --- | ------------------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P1  | Agendamento manual e descentralizado             | Agendamentos feitos via WhatsApp ou caderno, sem visão consolidada da agenda, dificultando o controle sobre atendimentos simultâneos e horários disponíveis |
| P2  | Ausência de cadastro estruturado de clientes     | Dados de clientes e veículos ficam dispersos ou existem apenas na memória do proprietário                                                                   |
| P3  | Falta de registro de observações por atendimento | Informações como estado do veículo, tipo de lavagem solicitada e cuidados específicos não são registradas de forma organizada                               |
| P4  | Sem histórico de atendimentos                    | Não há como consultar serviços anteriores de um cliente, dificultando a personalização e a fidelização                                                      |
| P5  | Falta de visibilidade sobre o negócio            | O proprietário não possui indicadores para entender a saúde financeira e operacional do estabelecimento                                                     |
| P6  | Capacidade operacional rígida                     | Configurar quantidade fixa de células de lavagem pode gerar divergência entre capacidade cadastrada e capacidade realmente ativa                             |
| P7  | Conflito de agendamento entre filiais             | Sem identificação de filial no agendamento e sem validação global por veículo, o mesmo carro pode ser agendado no mesmo horário em unidades diferentes      |

---

### 2.3 Impacto dos Problemas

| Problema | Impacto                                                                                                                                                                     |
| -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P1       | Sem visão clara da agenda, o estabelecimento perde o controle sobre quantos atendimentos estão em andamento simultaneamente e deixa horários vagos por falta de organização |
| P2       | Impossibilidade de contato proativo com clientes para promoções ou lembretes                                                                                                |
| P3       | Retrabalho e insatisfação quando preferências do cliente não são respeitadas                                                                                                |
| P4       | Perda de oportunidades de fidelização e incapacidade de oferecer atendimento personalizado                                                                                  |
| P5       | Decisões de negócio tomadas sem dados, dificultando planejamento e crescimento                                                                                              |
| P6       | Bloqueios indevidos ou superlotação da agenda por configuração incorreta da capacidade de lavagem                                                                          |
| P7       | Inconsistência operacional e atrito com cliente por dupla reserva do mesmo veículo no mesmo horário na mesma ou em outra filial                                            |

---

### 2.4 Solução Proposta

Desenvolvimento de um sistema web de gestão interna (ERP) que centraliza toda a operação do estabelecimento em uma única plataforma acessível via navegador. A solução endereça cada problema identificado:

- **P1 →** Agenda digital com visualização consolidada de todos os atendimentos, incluindo suporte a agendamentos simultâneos no mesmo horário
- **P2 →** Cadastro estruturado de clientes e veículos com dados de contato para comunicação
- **P3 →** Campo de observações logísticas vinculado a cada agendamento
- **P4 →** Histórico completo de atendimentos por cliente, acessível a qualquer momento
- **P5 →** Dashboard com indicadores operacionais e financeiros
- **P6 →** Configuração de células de lavagem ativas por filial com campo numérico livre de 1 a 100
- **P7 →** Seleção obrigatória de filial no agendamento e bloqueio de conflito do mesmo veículo no mesmo horário na mesma ou em outras filiais

---

## 3. Visão do Produto

### 3.1 Declaração de Visão

Para **proprietários e funcionários de estabelecimentos de estética automotiva** que enfrentam desorganização operacional e falta de controle sobre agendamentos e clientes, o **CarWash** é um **sistema web de gestão interna** que centraliza a operação do negócio em uma plataforma acessível e intuitiva. Diferente do controle manual por cadernos e aplicativos de mensagens, o CarWash oferece uma agenda digital integrada, cadastro estruturado e indicadores de desempenho em tempo real.

---

### 3.2 Objetivos do Produto

- **Digitalização operacional:** Substituir controles manuais e dispersos por um registro unificado e digital de clientes, veículos e agendamentos.
- **Gestão de fluxo e recorrência:** Estabelecer um controle eficiente sobre a agenda para reduzir ociosidade e garantir consistência nos atendimentos, especialmente de clientes recorrentes.
- **Operação multiunidade:** Permitir controle de filiais no fluxo de agendamento com rastreabilidade por unidade.
- **Capacidade flexível:** Ajustar dinamicamente a quantidade de células de lavagem ativas por filial, de 1 a 100, conforme operação real.
- **Acessibilidade e mobilidade:** Disponibilizar a plataforma 100% online, acessível de qualquer dispositivo com navegador, permitindo que o proprietário gerencie o negócio de qualquer lugar.
- **Profissionalização do atendimento:** Automatizar confirmações e lembretes de agendamento, elevando a percepção de profissionalismo perante os clientes.
- **Visibilidade do negócio:** Fornecer um dashboard com indicadores que apoiem a tomada de decisão baseada em dados.

---

### 3.3 Benefícios Esperados

| Benefício                    | Descrição                                                                                                     | Problema relacionado |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------- | -------------------- |
| Redução da ociosidade        | Visão clara da agenda, com suporte a atendimentos simultâneos, permite identificar e preencher horários vagos | P1                   |
| Previsibilidade financeira   | Histórico de atendimentos e indicadores permitem projetar faturamento                                         | P5                   |
| Centralização de informações | Todos os dados do negócio em um único lugar, acessíveis por toda a equipe                                     | P2, P4               |
| Mobilidade operacional       | Acesso ao sistema de qualquer dispositivo com internet                                                        | —                    |
| Profissionalização da marca  | Confirmações automáticas e atendimento personalizado elevam a imagem do negócio                               | P3, P4               |
| Agilidade no atendimento     | Consulta rápida ao histórico e preferências do cliente durante o atendimento                                  | P3, P4               |
| Segurança da informação      | Dados armazenados em nuvem, eliminando o risco de perda de cadernos ou anotações físicas                      | P2                   |

---

## 4. Stakeholders e Usuários

### 4.1 Stakeholders

| Stakeholder                 | Interesse no projeto                                                                                   |
| --------------------------- | ------------------------------------------------------------------------------------------------------ |
| Proprietário                | Principal interessado; busca organização do negócio, redução de perdas e visibilidade sobre a operação |
| Funcionários                | Utilizarão o sistema diariamente para consultar agenda e registrar atendimentos                        |
| Clientes do estabelecimento | Beneficiários indiretos; receberão confirmações automáticas e atendimento mais personalizado           |
| Equipe de desenvolvimento   | Responsável pela construção, testes e entrega do sistema conforme este documento                       |

---

### 4.2 Perfis de Usuário

#### Administrador (Proprietário)

| Aspecto                    | Descrição                                                                                 |
| -------------------------- | ----------------------------------------------------------------------------------------- |
| Papel                      | Gestor do negócio e administrador do sistema                                              |
| Principais atividades      | Configurar serviços, consultar dashboard, gerenciar agenda, cadastrar clientes e veículos |
| Experiência com tecnologia | Básica a intermediária (usa smartphone e WhatsApp no dia a dia)                           |
| Frequência de uso          | Diária                                                                                    |
| Nível de acesso            | Completo — todas as funcionalidades do sistema                                            |

#### Funcionário (Operador)

| Aspecto                    | Descrição                                                                                                        |
| -------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| Papel                      | Executor dos serviços e operador do sistema                                                                      |
| Principais atividades      | Consultar agenda, registrar observações, cadastrar clientes e veículos, visualizar detalhes do agendamento       |
| Experiência com tecnologia | Básica                                                                                                           |
| Frequência de uso          | Diária                                                                                                           |
| Nível de acesso            | Completo — mesmo nível do administrador nesta versão (diferenciação de permissões prevista para versões futuras) |

---

### 4.3 Responsabilidades por Stakeholder

> **Nota:** Na versão atual do sistema, administrador e funcionário possuem o mesmo nível de acesso a todas as funcionalidades. A diferenciação de permissões está prevista para versões futuras. A tabela abaixo reflete a intenção de uso esperada por perfil, não uma restrição técnica imposta pelo sistema.

| Responsabilidade                     | Administrador | Funcionário |
| ------------------------------------ | ------------- | ----------- |
| Cadastro e edição de clientes        | ✔             | ✔           |
| Cadastro e edição de veículos        | ✔             | ✔           |
| Criação e gestão de agendamentos     | ✔             | ✔           |
| Configuração do catálogo de serviços | ✔             | ✔           |
| Consulta à agenda                    | ✔             | ✔           |
| Registro de observações logísticas   | ✔             | ✔           |
| Visualização do dashboard            | ✔             | ✔           |
| Gerenciamento de usuários do sistema | ✔             | ✔           |

---

## 5. Escopo do Produto

### 5.1 Funcionalidades Principais (Priorizadas por MoSCoW)

#### Must Have (Essencial para o MVP)

| Funcionalidade           | Descrição                                                                                                                                                                                                                                     |
| ------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Autenticação de usuários | Login com e-mail e senha e controle de sessão. Na versão atual, todos os usuários possuem o mesmo nível de acesso; a diferenciação de permissões por perfil está prevista para versões futuras                                                |
| Cadastro de clientes     | Registro de nome, telefone, e-mail e endereço, com validação de dados obrigatórios e inclusão de responsáveis autorizados para agir em nome do titular com Nome, Telefone e CPF ou RG                                                            |
| Gestão de veículos       | Veículos vinculados ao cliente, com inclusão no momento do cadastro do cliente e visualização na tela detalhada do cliente                                                                                                                     |
| Gestão de filiais        | Cadastro e seleção de filial de atendimento para organizar a operação por unidade                                                                                                                                                              |
| Capacidade operacional   | Configuração da quantidade de células de lavagem ativas por filial com campo numérico livre entre 1 e 100                                                                                                                                     |
| Agenda digital           | Visualização da agenda por dia/semana com criação, edição e cancelamento de agendamentos. O sistema permite múltiplos agendamentos no mesmo horário conforme capacidade ativa da filial, exige seleção de filial e registra titular e responsável no atendimento |
| Seleção de serviços      | Associação de um ou mais serviços do catálogo a cada agendamento, com cálculo automático de duração                                                                                                                                           |
| Observações logísticas   | Campo de texto livre por agendamento para registrar estado do veículo, cuidados e preferências do cliente                                                                                                                                     |
| Temas claro e escuro     | Possibilidade de alternar a interface entre modo claro e escuro                                                                                                                                                                               |

#### Should Have (Importante, mas não bloqueia o MVP)

| Funcionalidade            | Descrição                                                                                                                 |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| Catálogo de serviços      | Tela para o administrador cadastrar, editar e desativar os tipos de serviço oferecidos com nome, preço e duração estimada |
| Confirmações automáticas  | Envio de mensagem automática ao cliente confirmando ou lembrando do agendamento                                           |
| Dashboard de indicadores  | Painel com métricas como total de atendimentos, faturamento estimado, taxa de ocupação e clientes ativos                  |
| Histórico de atendimentos | Consulta ao histórico completo de serviços realizados por cliente                                                         |

#### Could Have (Desejável para versões futuras)

| Funcionalidade                         | Descrição                                                                                                              |
| -------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| Diferenciação de permissões por perfil | Restrição de funcionalidades por tipo de usuário (ex: funcionário sem acesso ao dashboard ou configuração de serviços) |
| Filtros e buscas avançadas             | Busca de clientes por nome, placa ou telefone; filtros na agenda por status ou tipo de serviço                         |

#### Won't Have (Fora do escopo desta versão)

| Funcionalidade                    | Justificativa                                                                  |
| --------------------------------- | ------------------------------------------------------------------------------ |
| Marketplace ou acesso público     | O sistema é de uso interno; clientes não acessam o sistema diretamente         |
| Processamento de pagamentos       | Pagamentos continuarão sendo geridos fora do sistema nesta versão              |
| Funcionamento offline             | O sistema depende de conexão com a internet por ser uma aplicação web em nuvem |
| Geração de relatórios exportáveis | Relatórios em PDF ou planilha serão considerados em versões futuras            |
| Recuperação de credenciais        | Na primeira versão, a redefinição de senha será feita pelo administrador       |
| Cálculo automático de taxas       | Precificação dinâmica e cálculos tributários não fazem parte do escopo         |

---

### 5.2 Limites do Sistema

- O sistema é de uso **exclusivamente interno**. Clientes do estabelecimento não terão acesso direto à plataforma.
- A solução não substitui um ERP completo de gestão empresarial; seu foco é a operação de agendamentos, clientes e serviços.
- Agendamentos finalizados não poderão ser alterados, apenas consultados no histórico.
- O mesmo veículo não poderá possuir dois agendamentos no mesmo horário, na mesma filial ou em filiais diferentes.
- A capacidade de atendimento por filial deverá ser configurável entre 1 e 100 células ativas.
- O projeto não inclui fornecimento de hardware; o estabelecimento deve dispor de seus próprios dispositivos.

---

## 6. Premissas e Restrições

### 6.1 Premissas

| #   | Premissa                                                                                                         |
| --- | ---------------------------------------------------------------------------------------------------------------- |
| A1  | O proprietário participará de validações periódicas durante o desenvolvimento para garantir aderência ao negócio |
| A2  | O estabelecimento possui pelo menos um dispositivo (computador, tablet ou smartphone) com navegador atualizado   |
| A3  | O local de operação possui conexão com a internet estável o suficiente para uso de aplicação web                 |
| A4  | Os funcionários receberão orientação básica sobre o uso do sistema antes da implantação                          |
| A5  | Os dados iniciais de clientes e serviços serão inseridos manualmente pelo proprietário na fase de implantação    |

---

### 6.2 Restrições

| #   | Restrição                                                                          |
| --- | ---------------------------------------------------------------------------------- |
| R1  | O sistema deve seguir a identidade visual definida para a marca do estabelecimento |
| R2  | O sistema depende de conexão com a internet para funcionar                         |
| R3  | O limite técnico de células de lavagem ativas por filial será de no máximo 100     |

---

## 7. Critérios de Sucesso

| #   | Critério                   | Meta mensurável                                                                                                                                           |
| --- | -------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| S1  | Organização da agenda      | Visibilidade completa sobre todos os atendimentos agendados (incluindo simultâneos) com zero agendamentos perdidos ou esquecidos após a adoção do sistema |
| S2  | Adoção do sistema          | O sistema deve ser utilizado diariamente pelo proprietário e funcionários após a implantação                                                              |
| S3  | Estabilidade da aplicação  | O sistema deve manter disponibilidade mínima de 95% durante o horário comercial                                                                           |
| S4  | Conformidade visual        | A interface deve seguir a identidade visual aprovada pelo proprietário                                                                                    |
| S5  | Automação de confirmações  | Quando a funcionalidade for ativada por CR e incluída no escopo vigente, 100% dos agendamentos criados devem gerar confirmação automática ao cliente      |
| S6  | Centralização dos dados    | Pelo menos 99% dos clientes ativos e seus veículos devem estar cadastrados no sistema em até 90 dias após a implantação                                   |
| S7  | Satisfação do proprietário | Aprovação formal do proprietário ao final da entrega do MVP                                                                                               |

---

## 8. Riscos do Projeto

### 8.1 Riscos Técnicos

| #   | Risco                                     | Probabilidade | Impacto | Mitigação                                                                              |
| --- | ----------------------------------------- | ------------- | ------- | -------------------------------------------------------------------------------------- |
| RT1 | Instabilidade de conexão no local         | Média         | Alto    | Exibir feedback claro ao usuário em caso de falha de conexão                           |
| RT2 | Falhas de segurança ou vazamento de dados | Baixa         | Alto    | Autenticação segura, criptografia de senhas e HTTPS obrigatório                        |
| RT3 | Problemas no deploy ou indisponibilidade  | Média         | Médio   | Utilizar serviço de hospedagem com alta disponibilidade; documentar processo de deploy |

---

### 8.2 Riscos Operacionais

| #   | Risco                                        | Probabilidade | Impacto | Mitigação                                                                              |
| --- | -------------------------------------------- | ------------- | ------- | -------------------------------------------------------------------------------------- |
| RO1 | Resistência dos usuários à adoção            | Alta          | Alto    | Treinamento prático antes da implantação; interface simples e intuitiva                |
| RO2 | Erros de cadastro por falta de familiaridade | Média         | Médio   | Validações de dados no formulário; mensagens de erro claras e orientativas             |
| RO3 | Proprietário indisponível para validações    | Média         | Alto    | Agendar sessões de validação com antecedência; definir um canal assíncrono de feedback |
| RO4 | Configuração incorreta de células ativas por filial | Média    | Alto    | Campo com limite de 1 a 100, valor padrão inicial e alerta de impacto na agenda        |
| RO5 | Agendamento duplicado do mesmo veículo no mesmo horário (mesma ou outra filial) | Média | Alto | Seleção obrigatória de filial e validação de conflito global de veículo por data/hora     |

---

### 8.3 Riscos de Negócio

| #   | Risco                                    | Probabilidade | Impacto | Mitigação                                                                                 |
| --- | ---------------------------------------- | ------------- | ------- | ----------------------------------------------------------------------------------------- |
| RN1 | Custos de hospedagem acima do previsto   | Baixa         | Médio   | Escolher plano de hospedagem escalável; monitorar consumo de recursos                     |
| RN2 | Sistema não atende às necessidades reais | Média         | Alto    | Validações frequentes com o proprietário; entregas baseadas em modelo cascata com sprints |

---

## 9. Aprovação do Documento

| Papel        | Nome | Data | Assinatura                                      |
| ------------ | ---- | ---- | ----------------------------------------------- |
| Autor        |      |      |                                                 |
| Proprietário |      |      |                                                 |
| Orientador   |      |      |                                                 |
