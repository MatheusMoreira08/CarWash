# Documento de Requisitos do Produto (DRP)

**Projeto:** CarWash\
**Versão:** 1.4\
**Autor:** Antonio Neto\
**Data:** 23/03/2026

---

## Histórico de Alterações

| Versão | Data       | Autor        | Descrição                               |
| ------ | ---------- | ------------ | --------------------------------------- |
| 1.0    | 19/03/2026 | Antonio Neto | Versão inicial do DRP com base no DVP-E |
| 1.1    | 20/03/2026 | Antonio Neto | Inclusão de filiais, células dinâmicas e responsáveis |
| 1.2    | 23/03/2026 | Antonio Neto | Ajuste de rastreabilidade do P2 para incluir RF021, RF022 e RF023 |
| 1.3    | 23/03/2026 | Antonio Neto | Inclusão de CAs testáveis críticos de multiunidade e responsáveis no agendamento |
| 1.4    | 23/03/2026 | Antonio Neto | Inclusão de CA de cobertura de testes de negócio para validações críticas novas |

---

## 1. Introdução

### 1.1 Propósito do Documento

Este Documento de Requisitos do Produto (DRP) detalha os requisitos funcionais, não funcionais, regras de negócio e critérios de aceitação do sistema CarWash, complementando o DVP-E.

O objetivo é transformar a visão e o escopo do produto em especificações claras para desenvolvimento, validação e testes.

---

### 1.2 Escopo do Documento

Este documento cobre:

- Requisitos funcionais priorizados para o MVP;
- Requisitos previstos para versões futuras;
- Regras de negócio operacionais;
- Requisitos não funcionais de qualidade;
- Estrutura de dados e validações;
- Fluxos principais de uso e rastreabilidade com os problemas de negócio.

Este documento não cobre detalhes de arquitetura técnica, infraestrutura de nuvem ou desenho visual de telas em alta fidelidade.

---

### 1.3 Definições, Acrônimos e Abreviações

| Termo        | Definição                                                                 |
| ------------ | ------------------------------------------------------------------------- |
| **DRP**      | Documento de Requisitos do Produto                                        |
| **DVP-E**    | Documento de Visão do Produto e Escopo                                    |
| **MVP**      | Minimum Viable Product — versão mínima viável do produto                  |
| **RF**       | Requisito Funcional                                                       |
| **RNF**      | Requisito Não Funcional                                                   |
| **RN**       | Regra de Negócio                                                          |
| **CRUD**     | Operações de criar, consultar, atualizar e excluir                        |
| **Dashboard**| Painel com indicadores do negócio                                         |

---

### 1.4 Referências de Base

- DVP-E do projeto CarWash (`dvp-e.md`);
- Registro da reunião de kick-off (`kick off.txt`);
- Registro da reunião com cliente (`reuniao cliente.txt`).

---

## 2. Visão Geral do Produto

### 2.1 Contexto Operacional

O CarWash é um sistema interno para estabelecimentos de estética automotiva. O foco é centralizar cadastro de clientes e veículos, organizar agenda, registrar atendimentos e oferecer visibilidade operacional.

O sistema não é marketplace e não possui acesso direto para clientes finais.

---

### 2.2 Perfis de Usuário

| Perfil         | Objetivo principal                                                                 | Nível de acesso (versão atual) |
| -------------- | ----------------------------------------------------------------------------------- | ------------------------------- |
| Administrador  | Gerenciar operação, serviços, agenda, usuários e indicadores                       | Completo                        |
| Funcionário    | Operar atendimento diário, agenda e cadastros necessários à execução dos serviços  | Completo                        |

> Na versão atual, administrador e funcionário possuem o mesmo nível de permissões. A diferenciação de acesso fica para versão futura.

---

### 2.3 Objetivos Funcionais do MVP

- Eliminar dependência de controles manuais e dispersos;
- Reduzir ociosidade causada por falhas de agendamento;
- Garantir histórico e rastreabilidade de atendimentos;
- Padronizar cadastro de clientes e veículos com validações;
- Controlar operação por filial com contexto explícito no agendamento;
- Ajustar capacidade operacional por filial com células ativas de 1 a 100;
- Disponibilizar visão de operação por meio de dashboard.

---

## 3. Requisitos Funcionais

### 3.1 Requisitos Funcionais do MVP

| ID    | Requisito | Prioridade | Critério de Aceitação |
| ----- | --------- | ---------- | --------------------- |
| RF001 | O sistema deve permitir autenticação com login e senha para usuários internos. | Must | Usuário válido acessa o sistema e sessão é iniciada com sucesso. |
| RF002 | O sistema deve permitir cadastro de clientes com nome, documento, contatos, endereço e observações. | Must | Cadastro é salvo com campos obrigatórios válidos e pode ser consultado depois. |
| RF003 | O sistema deve validar limites e formatos de campos de cliente (nome, CPF, CNPJ, telefone/celular). | Must | Registros inválidos são bloqueados com mensagem clara de validação. |
| RF004 | O sistema deve permitir cadastro de veículos vinculados a um cliente existente. | Must | Não é possível salvar veículo sem cliente associado. |
| RF005 | O sistema deve validar placa e impedir duplicidade de placa no cadastro de veículos. | Must | Tentativa de duplicar placa retorna erro e não salva o registro. |
| RF006 | O sistema deve manter catálogo de serviços com tipo, preço e duração estimada. | Should | Usuário consegue cadastrar, editar e desativar serviço no catálogo. |
| RF007 | O sistema deve permitir criação de agendamento com cliente, veículo e um ou mais serviços. | Must | Agendamento salvo exibe os itens vinculados e pode ser consultado na agenda. |
| RF008 | O sistema deve permitir agendamentos simultâneos no mesmo horário. | Must | Dois agendamentos no mesmo horário são criados sem bloqueio indevido. |
| RF009 | O sistema deve permitir visualizar agenda em formato simples e detalhado. | Must | Lista da data mostra resumo e opção de ver detalhes completos do atendimento. |
| RF010 | O sistema deve permitir cancelamento de agendamento e bloquear edição de agendamento finalizado. | Must | Agendamento finalizado não pode ser alterado; cancelamento permanece registrado. |
| RF011 | O sistema deve permitir registrar observações logísticas por agendamento. | Must | Observações ficam salvas e visíveis em consultas futuras do atendimento. |
| RF012 | O sistema deve permitir consultar histórico de atendimentos por cliente. | Should | Busca por cliente retorna lista cronológica de serviços já realizados. |
| RF013 | O sistema deve disponibilizar dashboard com métricas operacionais e financeiras básicas. | Should | Painel mostra ao menos total de atendimentos, ocupação e faturamento estimado. |
| RF014 | O sistema deve permitir cadastro básico de usuários internos para acesso à plataforma. | Should | Usuário interno ativo consegue autenticar e usuário inativo não consegue acessar. |
| RF015 | O sistema deve permitir confirmação das informações antes de concluir um agendamento. | Must | Tela final mostra resumo e exige confirmação explícita para gravação. |
| RF016 | O sistema deve permitir alternância entre tema claro e tema escuro na interface. | Must | Usuário consegue trocar o tema e a preferência é aplicada nas principais telas do sistema. |
| RF017 | O sistema deve permitir cadastro de filiais para operação multiunidade. | Must | Usuário consegue criar filial ativa para uso no agendamento. |
| RF018 | O sistema deve permitir configurar quantidade de células de lavagem ativas por filial com valor entre 1 e 100. | Must | Valor fora da faixa é bloqueado e valor válido é salvo por filial. |
| RF019 | O sistema deve exigir seleção de filial no momento da criação do agendamento. | Must | Agendamento não é salvo sem filial definida. |
| RF020 | O sistema deve impedir agendamento do mesmo veículo no mesmo horário na mesma filial ou em filiais diferentes. | Must | Tentativa de conflito retorna erro e bloqueia gravação. |
| RF021 | O sistema deve permitir adicionar veículo no fluxo de cadastro de cliente. | Must | Usuário conclui cadastro do cliente com um ou mais veículos vinculados. |
| RF022 | O sistema deve exibir veículos do cliente na visualização detalhada de cliente. | Must | Lista de veículos vinculados aparece ao abrir detalhe do cliente. |
| RF023 | O sistema deve permitir cadastro de responsáveis vinculados ao cliente titular com Nome, Telefone e CPF ou RG. | Must | Responsáveis ficam associados ao cliente e podem ser selecionados em agendamentos. |
| RF024 | O sistema deve permitir selecionar no agendamento o responsável que está com o veículo no momento do atendimento. | Must | Agendamento exibe titular do veículo e responsável selecionado no momento da criação/consulta. |

---

### 3.2 Requisitos Funcionais para Versões Futuras

| ID         | Requisito | Origem |
| ---------- | --------- | ------ |
| RF-FUT001  | Recuperação de credenciais por link “Esqueci minha senha”. | Kick-off |
| RF-FUT002  | Geração de PDF de termos contratuais após confirmação do agendamento. | Kick-off |
| RF-FUT003  | Diferenciação de permissões por perfil de usuário. | DVP-E |
| RF-FUT004  | Filtros e buscas avançadas na agenda e cadastros. | DVP-E |

---

## 4. Regras de Negócio

| ID    | Regra de Negócio |
| ----- | ---------------- |
| RN001 | O sistema é de uso interno do estabelecimento e não oferece portal público para clientes. |
| RN002 | Todo veículo cadastrado deve estar obrigatoriamente vinculado a um cliente. |
| RN003 | Placas duplicadas não podem ser cadastradas no sistema. |
| RN004 | Agendamentos finalizados não podem ser editados, apenas consultados. |
| RN005 | Agendamentos podem ser simultâneos no mesmo horário conforme capacidade operacional do negócio. |
| RN006 | Serviços de um agendamento podem ser alterados enquanto o atendimento não estiver finalizado. |
| RN007 | O sistema deve registrar histórico de alterações relevantes de agendamento para auditoria operacional. |
| RN008 | A taxa de pré-pagamento para agendamento é assunto de regra comercial e permanece pendente de validação final do cliente para implementação. |
| RN009 | Cada filial deve possuir configuração de células de lavagem ativas com limite mínimo de 1 e máximo de 100. |
| RN010 | Todo agendamento deve estar vinculado obrigatoriamente a uma filial. |
| RN011 | O mesmo veículo não pode possuir dois agendamentos no mesmo horário, na mesma filial ou em filiais diferentes. |
| RN012 | O vínculo de veículos deve ser mantido dentro do cadastro de cliente e consultado no detalhe do cliente. |
| RN013 | Responsáveis cadastrados podem levar veículo e criar agendamentos em nome do cliente titular. |
| RN014 | Quando um novo responsável chegar sem cadastro prévio, o administrador deve cadastrá-lo no cliente titular antes de concluir o agendamento. |

---

## 5. Requisitos Não Funcionais

| ID     | Requisito Não Funcional | Meta / Critério |
| ------ | ------------------------ | --------------- |
| RNF001 | Usabilidade | Interface simples para usuários com conhecimento básico de tecnologia. |
| RNF002 | Disponibilidade | Disponibilidade mínima de 95% no horário comercial. |
| RNF003 | Segurança de acesso | Senhas armazenadas de forma segura; uso obrigatório de autenticação no sistema. |
| RNF004 | Proteção de dados | Tráfego via HTTPS e controle de sessão de usuário autenticado. |
| RNF005 | Performance | Operações de consulta comuns devem responder de forma fluida para uso diário. |
| RNF006 | Compatibilidade | Aplicação acessível em navegadores atuais de desktop e mobile. |
| RNF007 | Responsividade | Uso possível em computador, tablet e smartphone com navegação web. |
| RNF008 | Acessibilidade | Suporte inicial a boas práticas de contraste, legibilidade e navegação clara. |
| RNF009 | Observabilidade | Registro de logs de eventos críticos (login, erros de validação, falhas operacionais). |
| RNF010 | Identidade visual | Interface alinhada ao padrão visual acordado com o cliente (base vermelho/preto) com suporte a tema claro e escuro. |
| RNF011 | Consistência multiunidade | Regras de conflito de veículo por data/hora devem ser aplicadas entre todas as filiais ativas. |

---

## 6. Requisitos de Dados e Validações

### 6.1 Entidades Principais

| Entidade | Finalidade |
| -------- | ---------- |
| Usuário | Controlar acesso e operação no sistema |
| Filial | Identificar unidade operacional e sua capacidade ativa de lavagem |
| Cliente | Manter dados cadastrais e contato |
| Responsável | Registrar pessoa autorizada a agir em nome do cliente titular |
| Veículo | Registrar veículos vinculados a clientes |
| Serviço | Definir catálogo comercial e operacional |
| Agendamento | Planejar execução de serviços por data/hora |
| Atendimento/Histórico | Consolidar execução e rastreabilidade |

---

### 6.2 Campos e Restrições Relevantes

| Entidade | Campo | Regra |
| -------- | ----- | ----- |
| Cliente | Nome completo | Obrigatório; até 50 caracteres |
| Cliente | CPF | Quando informado, 11 dígitos válidos |
| Cliente | CNPJ | Quando informado, 14 dígitos válidos |
| Cliente | Celular | Quando informado, 11 dígitos |
| Cliente | Telefone fixo | Quando informado, validar formato definido |
| Responsável | Nome | Obrigatório |
| Responsável | Telefone | Obrigatório; validar formato definido |
| Responsável | CPF ou RG | Obrigatório; ao menos um dos dois deve ser informado |
| Cliente | Responsáveis | Um ou mais responsáveis vinculados ao titular |
| Veículo | Placa | Obrigatória; sem caracteres especiais; única no sistema |
| Veículo | Modelo/Fabricante/Cor | Obrigatórios para cadastro completo |
| Veículo | Cliente vinculado | Obrigatório |
| Filial | Nome da filial | Obrigatório |
| Filial | Células de lavagem ativas | Obrigatório; número inteiro de 1 a 100 |
| Serviço | Nome do serviço | Obrigatório |
| Serviço | Preço | Obrigatório; valor positivo |
| Serviço | Duração estimada | Obrigatória; maior que zero |
| Agendamento | Cliente, veículo e serviço(s) | Obrigatórios |
| Agendamento | Filial | Obrigatória |
| Agendamento | Responsável atual pelo veículo | Deve ser selecionado entre titular e responsáveis vinculados ao cliente |
| Agendamento | Veículo + data/hora | Deve ser único no mesmo horário na mesma filial e entre filiais |
| Agendamento | Status | Deve suportar ao menos: agendado, cancelado, finalizado |
| Agendamento | Observações logísticas | Campo livre opcional |

---

## 7. Fluxos Principais (Casos de Uso Resumidos)

| ID      | Caso de Uso | Atores | Resultado Esperado |
| ------- | ----------- | ------ | ------------------ |
| UC001 | Realizar login | Administrador, Funcionário | Usuário autenticado e direcionado ao painel inicial |
| UC002 | Cadastrar cliente | Administrador, Funcionário | Cliente salvo com validações de campos |
| UC003 | Cadastrar veículo | Administrador, Funcionário | Veículo salvo, vinculado ao cliente e sem placa duplicada |
| UC004 | Criar agendamento | Administrador, Funcionário | Agendamento registrado com confirmação final |
| UC005 | Consultar agenda detalhada | Administrador, Funcionário | Usuário visualiza resumo e detalhe dos atendimentos |
| UC006 | Cancelar agendamento | Administrador, Funcionário | Agendamento marcado como cancelado, mantendo histórico |
| UC007 | Registrar observações do atendimento | Administrador, Funcionário | Informações operacionais ficam disponíveis no histórico |
| UC008 | Consultar dashboard | Administrador, Funcionário | Indicadores de operação apresentados para análise |
| UC009 | Configurar filial e células ativas | Administrador, Funcionário | Filial fica apta para operação com capacidade definida de 1 a 100 |
| UC010 | Cadastrar responsável do cliente | Administrador, Funcionário | Responsável vinculado ao cliente titular para uso em agendamentos |
| UC011 | Agendar com responsável do titular | Administrador, Funcionário | Agendamento registra titular do veículo e responsável selecionado no momento |

---

## 8. Itens Fora do Escopo do MVP

| Item | Justificativa |
| ---- | ------------- |
| Marketplace público para clientes | Produto é sistema interno de gestão |
| Processamento completo de pagamentos | Escopo inicial prioriza operação e controle |
| Funcionamento offline | Plataforma web depende de internet |
| Recuperação de senha no próprio sistema | Planejado para versão futura |
| Geração de termos PDF de contrato | Planejado para versão futura |
| Relatórios exportáveis avançados | Planejado para versões futuras |

---

## 9. Matriz de Rastreabilidade (Problema x Requisitos)

| Problema de Negócio (DVP-E) | Requisitos Relacionados |
| --------------------------- | ----------------------- |
| P1 — Agendamento desorganizado | RF007, RF008, RF009, RF015 |
| P2 — Cadastro disperso de clientes | RF002, RF003, RF004, RF005, RF021, RF022, RF023, RF024 |
| P3 — Falta de observações operacionais | RF011 |
| P4 — Ausência de histórico | RF012 |
| P5 — Falta de visibilidade do negócio | RF013 |
| P6 — Capacidade operacional rígida | RF017, RF018, RF019 |
| P7 — Conflito de agendamento entre filiais | RF019, RF020 |

---

## 10. Critérios de Aceite da Entrega do MVP

| ID   | Critério |
| ---- | -------- |
| CA001 | Todos os requisitos Must (RF001, RF002, RF003, RF004, RF005, RF007, RF008, RF009, RF010, RF011, RF015, RF016, RF017, RF018, RF019, RF020, RF021, RF022, RF023, RF024) implementados e homologados |
| CA002 | Fluxo completo de cadastro e agendamento executado sem bloqueios operacionais críticos |
| CA003 | Validações de dados obrigatórios e duplicidade de placa funcionando corretamente |
| CA004 | Disponibilidade e estabilidade compatíveis com operação diária do estabelecimento |
| CA005 | Aprovação formal do proprietário sobre uso prático no contexto real de operação |
| CA006 | Mesmo veículo em mesmo horário na mesma filial ou em filiais diferentes deve bloquear agendamento |
| CA007 | Agendamento sem filial deve falhar com mensagem clara de validação |
| CA008 | Configuração de células por filial deve aceitar somente valores inteiros entre 1 e 100 |
| CA009 | Responsável autorizado pode agendar em nome do titular e deve ficar registrado no agendamento |
| CA010 | Ao cadastrar novo responsável no cliente titular, ele deve aparecer na seleção de responsável no próximo agendamento |
| CA011 | Testes de negócio devem validar CA006, CA007, CA008, CA009 e CA010 em homologação |

---

## 11. Aprovação do Documento

| Papel        | Nome | Data | Assinatura |
| ------------ | ---- | ---- | ---------- |
| Autor        |      |      |            |
| Proprietário |      |      |            |
| Orientador   |      |      |            |
