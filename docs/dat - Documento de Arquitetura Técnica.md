# Documento de Arquitetura Técnica (DAT)

**Projeto:** CarWash  
**Versão:** 1.0  
**Autor:** Guilherme Brogio  
**Data:** 20/03/2026

---

## Histórico de Alterações

| Versão | Data       | Autor                            | Descrição                                        |
| ------ | ---------- | -------------------------------- | ------------------------------------------------ |
| 1.0    | 20/03/2026 | Guilherme Brogio Macedo da Silva | Versão inicial da arquitetura técnica do CarWash |

---

## 1. Introdução

### 1.1 Propósito do Documento

Este Documento de Arquitetura Técnica (DAT) define a arquitetura de software do sistema CarWash para orientar implementação, testes, evolução e operação do produto.

O documento transforma os requisitos do DRP em decisões técnicas de estrutura, componentes, dados, segurança, disponibilidade e implantação.

---

### 1.2 Escopo do Documento

Este documento cobre:

- Visão arquitetural da solução web;
- Organização por camadas e módulos;
- Arquitetura de dados e regras de integridade;
- Arquitetura de segurança e controle de acesso;
- Estratégia de infraestrutura, deploy e observabilidade;
- Mapeamento de requisitos não funcionais para decisões técnicas;
- Riscos técnicos e plano de evolução arquitetural.

Este documento não cobre protótipos visuais de telas, plano detalhado de testes manuais, contratos comerciais ou orçamento financeiro definitivo.

---

### 1.3 Definições, Acrônimos e Abreviações

| Termo     | Definição                                                         |
| --------- | ----------------------------------------------------------------- |
| **DAT**   | Documento de Arquitetura Técnica                                  |
| **DVP-E** | Documento de Visão do Produto e Escopo                            |
| **DVS**   | Documento de Viabilidade de Software                              |
| **DRP**   | Documento de Requisitos do Produto                                |
| **MVP**   | Minimum Viable Product — versão mínima viável                     |
| **API**   | Interface de comunicação entre componentes                        |
| **CRUD**  | Operações de criar, consultar, atualizar e excluir                |
| **RBAC**  | Role-Based Access Control — controle de acesso por papel          |
| **RPO**   | Recovery Point Objective — tolerância de perda de dados           |
| **RTO**   | Recovery Time Objective — tempo alvo para recuperação de operação |

---

### 1.4 Referências de Base

- DVP-E CarWash (`2-dvp-e.md`);
- DRP CarWash (`3-drp.md`);
- DVS CarWash (`1-dvs.md`);
- Reuniões de kick-off e alinhamento com cliente.

---

### 1.5 Visão Geral do Documento

- **Seção 1** — Introdução
- **Seção 2** — Drivers Arquiteturais e Restrições
- **Seção 3** — Visão Geral da Arquitetura e Stack
- **Seção 4** — Arquitetura Lógica e Módulos
- **Seção 5** — Arquitetura de Dados
- **Seção 6** — Arquitetura de Segurança
- **Seção 7** — Requisitos Não Funcionais e Estratégias
- **Seção 8** — Infraestrutura, Deploy e Operação
- **Seção 9** — Observabilidade e Suporte
- **Seção 10** — Riscos Técnicos e Mitigações
- **Seção 11** — Roadmap de Evolução Técnica
- **Seção 12** — Aprovação

---

## 2. Drivers Arquiteturais e Restrições

### 2.1 Drivers de Negócio

| ID  | Driver                                                                 | Origem    |
| --- | ---------------------------------------------------------------------- | --------- |
| DA1 | Centralizar agenda, clientes, veículos e serviços em uma única solução | DVP-E     |
| DA2 | Reduzir desorganização operacional e ociosidade                        | DVP-E     |
| DA3 | Garantir uso diário por usuários com conhecimento técnico básico       | DVP-E/DRP |
| DA4 | Entregar MVP incremental com foco em requisitos Must                   | DRP/DVS   |
| DA5 | Sustentar crescimento funcional sem reescrita da base                  | DVS       |

---

### 2.2 Restrições Técnicas

| ID  | Restrição                                                                  |
| --- | -------------------------------------------------------------------------- |
| RT1 | Aplicação web com dependência de internet (sem modo offline no MVP)        |
| RT2 | Solução de uso interno (sem portal público para cliente final)             |
| RT3 | Segurança mínima obrigatória: autenticação, HTTPS, proteção de senha       |
| RT4 | Disponibilidade alvo mínima de 95% no horário comercial                    |
| RT5 | Operação inicial com perfis de acesso equivalentes (RBAC detalhado futuro) |

---

## 3. Visão Geral da Arquitetura

### 3.1 Estilo Arquitetural

A arquitetura adota estilo **cliente-servidor em camadas**, com separação entre:

1. **Camada de Apresentação (Frontend Web)** para interface e experiência do usuário;
2. **Camada de Aplicação (Backend/API)** para regras de negócio e orquestração;
3. **Camada de Persistência (Banco de Dados Relacional)** para armazenamento estruturado e consistente.

Esse estilo reduz acoplamento, facilita manutenção e permite evolução gradual por módulos.

---

### 3.2 Stack Tecnológica Definida

| Camada | Stack escolhida | Justificativa técnica |
| ------ | --------------- | --------------------- |
| Frontend | React | Maior adesão e conhecimento do time, acelerando entrega do MVP e manutenção contínua |
| Backend/API | C# com .NET | Escolha técnica alinhada ao solicitado pelo cliente Fabrício e com alta praticidade para modelagem orientada a objetos (POO) |
| Banco de Dados | PostgreSQL | Banco relacional robusto para integridade transacional, consultas estruturadas e evolução segura do domínio |

**Diretriz de arquitetura para o time:**

- Frontend implementado com React e consumo de API REST;
- Backend implementado em C#/.NET com camadas de domínio, aplicação e infraestrutura;
- Persistência em PostgreSQL com foco em integridade, rastreabilidade e desempenho em consultas operacionais.

---

### 3.3 Visão de Componentes

| Camada      | Componente              | Responsabilidade principal                                    |
| ----------- | ----------------------- | ------------------------------------------------------------- |
| Frontend    | Interface Web           | Fluxos de login, cadastros, agenda, dashboard                 |
| Backend/API | Serviço de Autenticação | Login, sessão, validação de credenciais                       |
| Backend/API | Serviço de Clientes     | CRUD de clientes e validações de dados                        |
| Backend/API | Serviço de Veículos     | CRUD de veículos e unicidade de placa                         |
| Backend/API | Serviço de Serviços     | Catálogo de serviços e parâmetros operacionais                |
| Backend/API | Serviço de Agenda       | Criação, consulta, cancelamento e finalização de agendamentos |
| Backend/API | Serviço de Histórico    | Registro e consulta de histórico de atendimento               |
| Backend/API | Serviço de Dashboard    | Agregações e métricas operacionais/financeiras                |
| Dados       | Banco Relacional        | Persistência transacional e integridade referencial           |
| Suporte     | Log/Auditoria           | Registro de eventos críticos e rastreabilidade                |

---

### 3.4 Fluxo Macro de Requisição

1. Usuário autenticado interage com a interface web;
2. Frontend envia requisições HTTPS para API;
3. API valida autenticação, regras de negócio e consistência;
4. Operações de leitura/escrita são executadas no banco relacional;
5. API retorna resposta estruturada para atualização da interface;
6. Eventos críticos (login, falha, alteração relevante) são registrados em log.

---

## 4. Arquitetura Lógica e Módulos

### 4.1 Módulos Funcionais do MVP

| Módulo               | Requisitos DRP relacionados       | Observações                                   |
| -------------------- | --------------------------------- | --------------------------------------------- |
| Autenticação         | RF001, RF014                      | Sessão obrigatória para acesso interno        |
| Cadastro de Clientes | RF002, RF003                      | Validação de campos e formatos                |
| Cadastro de Veículos | RF004, RF005                      | Vínculo obrigatório com cliente e placa única |
| Catálogo de Serviços | RF006                             | Base para composição dos agendamentos         |
| Agenda               | RF007, RF008, RF009, RF010, RF015 | Suporte a agendamentos simultâneos            |
| Observações          | RF011                             | Registro logístico por atendimento            |
| Histórico            | RF012                             | Consulta de atendimentos anteriores           |
| Dashboard            | RF013                             | Indicadores para gestão operacional           |
| Temas da Interface   | RF016                             | Suporte a tema claro/escuro                   |

---

### 4.2 Regras de Encapsulamento

- Regras de negócio ficam centralizadas no backend;
- Frontend não implementa lógica crítica de validação de domínio;
- Acesso ao banco ocorre somente pela camada de aplicação;
- Serviços compartilham contratos de dados versionados;
- Mudanças de esquema de dados exigem migrações controladas.

---

## 5. Arquitetura de Dados

### 5.1 Modelo Conceitual de Entidades

| Entidade    | Relacionamentos principais           | Regras de integridade                             |
| ----------- | ------------------------------------ | ------------------------------------------------- |
| Usuário     | 1:N com Agendamento (criação/edição) | Usuário ativo para autenticação                   |
| Cliente     | 1:N com Veículo; 1:N com Agendamento | Campos obrigatórios validados                     |
| Veículo     | N:1 com Cliente; 1:N com Agendamento | Placa única no sistema                            |
| Serviço     | N:N com Agendamento                  | Nome, preço e duração obrigatórios                |
| Agendamento | N:1 com Cliente; N:1 com Veículo     | Status controlado (agendado/cancelado/finalizado) |
| Histórico   | N:1 com Agendamento e Cliente        | Registro imutável após finalização                |

---

### 5.2 Política de Consistência e Transações

| Cenário                                             | Estratégia técnica                                           |
| --------------------------------------------------- | ------------------------------------------------------------ |
| Criação de agendamento com múltiplos serviços       | Transação única para manter atomicidade                      |
| Cancelamento/finalização de agendamento             | Atualização transacional com trilha de auditoria             |
| Atualização de cadastros críticos (cliente/veículo) | Validação antes de persistir e bloqueio de duplicidade       |
| Cálculo de indicadores do dashboard                 | Consulta agregada por período com tratamento de consistência |

---

### 5.3 Retenção e Backup

| Item                           | Diretriz                                                    |
| ------------------------------ | ----------------------------------------------------------- |
| Retenção de dados operacionais | Manutenção integral no MVP para histórico e rastreabilidade |
| Backup de banco                | Rotina automática diária com política de retenção mínima    |
| RPO alvo                       | Até 24 horas                                                |
| RTO alvo                       | Até 8 horas para recuperação operacional inicial            |

---

### 5.4 Justificativa do PostgreSQL com base no PACELC

A escolha do PostgreSQL considera o perfil do CarWash como sistema transacional interno, com alta necessidade de consistência em cadastros e agendamentos.

Sob a ótica do PACELC:

- **P/C:** em cenário de partição de rede, a prioridade arquitetural é manter consistência dos dados críticos (clientes, veículos, agenda), mesmo com possível degradação temporária de disponibilidade;
- **E/C:** fora de partições, a decisão privilegia consistência e integridade referencial sobre ganhos marginais de latência.

Em termos práticos, isso reduz risco de conflitos como duplicidade de registros e divergências de status de agendamento, mantendo aderência aos requisitos funcionais e de auditoria do DRP.

---

## 6. Arquitetura de Segurança

### 6.1 Controles de Segurança do MVP

| Controle                      | Aplicação no CarWash                                  |
| ----------------------------- | ----------------------------------------------------- |
| Autenticação obrigatória      | Acesso apenas por usuários internos cadastrados       |
| Armazenamento seguro de senha | Senhas com hash forte e sal                           |
| Tráfego protegido             | Comunicação exclusivamente via HTTPS                  |
| Controle de sessão            | Sessão com tempo de expiração e invalidação em logout |
| Validação de entrada          | Sanitização e validação de payload em backend         |
| Registro de eventos críticos  | Logs para login, falhas e alterações relevantes       |

---

### 6.2 Controle de Acesso

No MVP, administrador e funcionário possuem permissões equivalentes, conforme decisões de escopo.

Para evolução futura, a arquitetura deve permitir RBAC por perfil sem quebra estrutural, com:

- Camada de autorização desacoplada da autenticação;
- Matriz de permissões por funcionalidade;
- Restrições por endpoint e ação.

---

## 7. Requisitos Não Funcionais e Estratégias

| RNF (DRP)                  | Meta                                    | Estratégia arquitetural                                      |
| -------------------------- | --------------------------------------- | ------------------------------------------------------------ |
| RNF001 Usabilidade         | Interface simples para perfil básico    | Fluxos curtos, feedback de validação e linguagem objetiva    |
| RNF002 Disponibilidade     | 95% no horário comercial                | Hospedagem estável, monitoramento e rotina de backup         |
| RNF003 Segurança de acesso | Autenticação obrigatória e senha segura | Hash de senha, política de sessão e proteção de rotas        |
| RNF004 Proteção de dados   | HTTPS e sessão protegida                | TLS, expiração de sessão e validações de entrada             |
| RNF005 Performance         | Uso fluido em consultas comuns          | Índices em campos críticos, paginação e consultas otimizadas |
| RNF006 Compatibilidade     | Navegadores atuais                      | Frontend responsivo e testes em navegadores alvo             |
| RNF007 Responsividade      | Desktop/tablet/mobile                   | Layout adaptativo e componentes responsivos                  |
| RNF008 Acessibilidade      | Contraste e legibilidade                | Padrões mínimos de contraste e hierarquia visual clara       |
| RNF009 Observabilidade     | Logs de eventos críticos                | Padronização de logs e trilha de auditoria                   |
| RNF010 Identidade visual   | Padrão visual acordado                  | Tema claro/escuro com paleta base vermelho/preto             |

---

## 8. Infraestrutura, Deploy e Operação

### 8.1 Ambientes

| Ambiente        | Objetivo                              | Requisitos mínimos                             |
| --------------- | ------------------------------------- | ---------------------------------------------- |
| Desenvolvimento | Construção e testes locais            | Banco isolado e variáveis de ambiente          |
| Homologação     | Validação funcional com usuário-chave | Base de teste e dados controlados              |
| Produção        | Operação real do negócio              | HTTPS ativo, backup automático e monitoramento |

---

### 8.2 Estratégia de Deploy

| Etapa                  | Diretriz                                                |
| ---------------------- | ------------------------------------------------------- |
| Build                  | Geração reprodutível de artefatos do frontend e backend |
| Migração de dados      | Execução versionada antes da ativação da release        |
| Publicação             | Deploy com rollback documentado                         |
| Verificação pós-deploy | Smoke test de login, cadastros e agenda                 |

---

### 8.3 Gestão de Configuração

- Configurações sensíveis via variáveis de ambiente;
- Segredos fora do código-fonte;
- Separação de configuração por ambiente;
- Política de rotação de credenciais em produção.

---

## 9. Observabilidade e Suporte

### 9.1 Logs e Auditoria

| Evento                              | Nível     | Finalidade                             |
| ----------------------------------- | --------- | -------------------------------------- |
| Tentativa de login (sucesso/falha)  | Segurança | Auditoria de acesso                    |
| Falha de validação de regra crítica | Aplicação | Diagnóstico de erro de uso/integridade |
| Alteração de status de agendamento  | Negócio   | Rastreabilidade operacional            |
| Exceções não tratadas               | Técnico   | Investigação de incidentes             |

---

### 9.2 Monitoramento Operacional

| Indicador                                  | Objetivo                            |
| ------------------------------------------ | ----------------------------------- |
| Disponibilidade da aplicação               | Confirmar aderência ao RNF002       |
| Tempo médio de resposta de APIs principais | Monitorar experiência de uso diário |
| Taxa de erro em operações críticas         | Identificar regressões e incidentes |
| Sucesso de backup diário                   | Garantir capacidade de recuperação  |

---

## 10. Riscos Técnicos e Mitigações

| ID    | Risco técnico                                         | Probabilidade | Impacto    | Mitigação                                                |
| ----- | ----------------------------------------------------- | ------------- | ---------- | -------------------------------------------------------- |
| RAT01 | Crescimento desordenado da base sem modelagem estável | Média         | Alto       | Governança de esquema e migrações versionadas            |
| RAT02 | Lentidão em consultas de agenda e dashboard           | Média         | Médio/Alto | Índices, paginação e otimização de consultas             |
| RAT03 | Vulnerabilidade por validação insuficiente de entrada | Baixa/Média   | Alto       | Validação server-side obrigatória e revisão de segurança |
| RAT04 | Falha de recuperação após incidente de banco          | Baixa/Média   | Alto       | Backup automatizado e teste periódico de restauração     |
| RAT05 | Acoplamento excessivo entre módulos                   | Média         | Médio      | Contratos claros de serviço e separação por domínio      |

---

## 11. Roadmap de Evolução Técnica

| Fase      | Evolução arquitetural prevista                           | Ganho esperado                         |
| --------- | -------------------------------------------------------- | -------------------------------------- |
| Pós-MVP 1 | RBAC completo por perfil e permissões por módulo         | Maior segurança e governança de acesso |
| Pós-MVP 2 | Recuperação de senha e fluxo seguro de credenciais       | Melhor autonomia operacional           |
| Pós-MVP 3 | Exportação de documentos (PDF) e trilhas avançadas       | Padronização operacional e compliance  |
| Pós-MVP 4 | Melhorias de busca/filtros e escalabilidade de consultas | Melhor desempenho e experiência de uso |

---

## 12. Aprovação do Documento

| Papel        | Nome | Data | Assinatura |
| ------------ | ---- | ---- | ---------- |
| Autor        |      |      |            |
| Proprietário |      |      |            |
| Orientador   |      |      |            |
