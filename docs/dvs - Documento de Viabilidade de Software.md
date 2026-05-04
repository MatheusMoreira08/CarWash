# Documento de Viabilidade de Software (DVS)

**Projeto:** CarWash\
**Versão:** 1.4\
**Autor:** Antonio Neto\
**Data:** 23/03/2026

---

## Histórico de Alterações

| Versão | Data       | Autor        | Descrição                                  |
| ------ | ---------- | ------------ | ------------------------------------------ |
| 1.0    | 19/03/2026 | Antonio Neto | Versão inicial do estudo de viabilidade    |
| 1.1    | 19/03/2026 | Antonio Neto | Inclusão das dimensões legal, cronograma e humana conforme slide |
| 1.2    | 20/03/2026 | Antonio Neto | Inclusão de filiais, células dinâmicas e novos riscos operacionais |
| 1.3    | 23/03/2026 | Antonio Neto | Consolidação de validações críticas de multiunidade, capacidade por filial e responsáveis no agendamento |
| 1.4    | 23/03/2026 | Antonio Neto | Ajuste de conflito global na mesma ou em outra filial e reforço de cobertura dos testes de negócio críticos |

---

## 1. Introdução

### 1.1 Propósito do Documento

Este Documento de Viabilidade de Software (DVS) avalia se o sistema CarWash é viável sob as perspectivas técnica, econômica, operacional, legal, de cronograma, humana e de riscos.

O objetivo é apoiar a decisão de continuidade do projeto com base em evidências levantadas nas reuniões de kick-off, reunião com cliente, DVP-E e DRP.

---

### 1.2 Escopo do Documento

Este documento cobre:

- Viabilidade técnica da solução web proposta;
- Viabilidade econômica em nível preliminar;
- Viabilidade operacional para o cenário real do cliente;
- Viabilidade legal e de conformidade;
- Viabilidade de prazo e execução do MVP;
- Viabilidade humana da equipe e da operação;
- Riscos críticos e plano de mitigação;
- Recomendação final de continuidade (Go/No-Go).

Este documento não cobre orçamento contratual fechado, desenho de arquitetura detalhada, plano de testes completo nem definição final de fornecedores de infraestrutura.

---

### 1.3 Definições, Acrônimos e Abreviações

| Termo     | Definição                                                                 |
| --------- | ------------------------------------------------------------------------- |
| **DVS**   | Documento de Viabilidade de Software                                      |
| **DVP-E** | Documento de Visão do Produto e Escopo                                    |
| **DRP**   | Documento de Requisitos do Produto                                        |
| **MVP**   | Minimum Viable Product — versão mínima viável                             |
| **Go**    | Decisão de continuidade do projeto                                        |
| **No-Go** | Decisão de não continuidade até resolução de impedimentos críticos        |
| **LGPD**  | Lei Geral de Proteção de Dados Pessoais                                  |

---

### 1.4 Visão Geral do Documento

- **Seção 1** — Introdução
- **Seção 2** — Contexto e Objetivo de Negócio
- **Seção 3** — Análise de Viabilidade
- **Seção 4** — Matriz de Riscos de Viabilidade
- **Seção 5** — Critérios de Decisão Go/No-Go
- **Seção 6** — Conclusão e Recomendação
- **Seção 7** — Aprovação

---

## 2. Contexto e Objetivo de Negócio

### 2.1 Contexto Atual

O negócio de estética automotiva opera com agendamento e controle de clientes de forma manual ou descentralizada. Isso gera horários ociosos, perda de controle da agenda e baixa rastreabilidade de informações operacionais.

---

### 2.2 Objetivo do Projeto

Implementar um sistema interno de gestão que centralize:

- Cadastro de clientes e veículos;
- Cadastro de responsáveis vinculados ao cliente titular;
- Catálogo de serviços e valores definidos pelo próprio cliente do sistema;
- Agenda com visão simples e detalhada por filial;
- Controle de filiais e capacidade ativa de células de lavagem (1 a 100 por filial);
- Registro de histórico e observações operacionais;
- Dashboard com indicadores operacionais e financeiros básicos.

---

### 2.3 Condicionantes de Negócio

| Item | Condicionante |
| ---- | ------------- |
| C1 | Solução de uso interno; não é marketplace |
| C2 | Interface deve considerar usuários com conhecimento básico de tecnologia |
| C3 | Identidade visual prevista: vermelho e preto, com tema claro/escuro |
| C4 | Regra de pré-pagamento de 30% ainda depende de validação comercial final |
| C5 | Comunicação com cliente pode envolver WhatsApp e e-mail |
| C6 | Operação pode ocorrer em múltiplas filiais e todo agendamento deve indicar a filial de execução |
| C7 | Quantidade de células ativas de lavagem é configurável por filial com limite de 1 a 100 |

---

## 3. Análise de Viabilidade

### 3.1 Viabilidade Técnica

| Critério | Avaliação | Evidência |
| -------- | --------- | --------- |
| Arquitetura da solução | Viável | Escopo orientado a aplicação web interna com módulos de cadastro, agenda, serviços e dashboard |
| Complexidade funcional do MVP | Viável com atenção | Requisitos do MVP são claros e incrementais, com funcionalidades futuras já separadas |
| Qualidade de dados | Viável com mitigação | Riscos de duplicidade (placa e cliente) foram identificados e podem ser tratados com validações e regras de unicidade |
| Consistência de agenda multiunidade | Viável com validação crítica | Necessário bloquear o mesmo veículo no mesmo horário na mesma filial e entre filiais, além de exigir filial no agendamento |
| Capacidade operacional configurável | Viável | Campo numérico de 1 a 100 células por filial reduz risco de configuração fixa divergente da operação real |
| Responsável no atendimento | Viável com regra explícita | Responsável deve ser vinculado ao cliente titular e selecionado no agendamento com dados mínimos obrigatórios |
| Segurança | Viável com requisitos mínimos obrigatórios | Uso de autenticação, armazenamento seguro de senha, HTTPS e logs críticos já previstos |
| Integrações externas | Baixa dependência no MVP | Fluxo principal não depende de integrações complexas para primeira entrega |

**Conclusão técnica:** viável, desde que sejam implementadas validações obrigatórias, proteção de dados e monitoramento de disponibilidade.

---

### 3.2 Viabilidade Operacional

| Critério | Avaliação | Evidência |
| -------- | --------- | --------- |
| Aderência ao processo real do negócio | Alta | Problemas levantados em reunião são diretamente cobertos pelo escopo funcional |
| Facilidade de adoção | Média/Alta | Perfil do usuário é básico; necessidade de interface simples e treinamento curto |
| Prontidão da operação | Média | Dependência de internet estável e disciplina de uso diário da equipe |
| Operação por filial | Média/Alta | Inclusão de filial no agendamento melhora organização, exigindo parametrização inicial das unidades |
| Sustentação no dia a dia | Viável | Sistema substitui controles dispersos por fluxo único e rastreável |

**Conclusão operacional:** viável, com plano de implantação assistida e treinamento inicial obrigatório.

---

### 3.3 Viabilidade Econômica (Preliminar)

| Bloco | Situação |
| ----- | -------- |
| Investimento inicial | Moderado para MVP de gestão interna |
| Custo recorrente esperado | Baixo a moderado (hospedagem, banco de dados e manutenção evolutiva) |
| Benefícios econômicos | Redução de ociosidade, menor retrabalho, melhor previsibilidade e retenção de clientes |
| Risco econômico principal | Retorno menor que o esperado em caso de baixa adoção da equipe |

**Leitura econômica:** viabilidade favorável em cenário de adoção contínua e uso diário do sistema.

---

### 3.4 Viabilidade Legal e de Conformidade

| Critério | Avaliação | Observação |
| -------- | --------- | ---------- |
| Proteção de dados pessoais | Viável com controles | Necessário limitar acesso, proteger sessão e evitar exposição indevida de dados |
| Rastreabilidade operacional | Viável | Logs de eventos críticos e histórico apoiam auditoria interna |
| Política comercial de 30% | Pendente de validação formal | Recomendado formalizar termo de uso antes de automação completa da regra |

**Conclusão de conformidade:** viável, com pendência comercial/jurídica sobre pré-pagamento.

---

### 3.5 Viabilidade de Cronograma

| Fase | Objetivo | Status de Viabilidade |
| ---- | -------- | --------------------- |
| Fase 1 | MVP com autenticação, cadastros, agenda por filial e regras críticas | Viável |
| Fase 2 | Dashboard ampliado, histórico consolidado e melhorias de experiência | Viável |
| Fase 3 | Funcionalidades futuras (PDF de termos e recuperação de senha) | Viável após estabilização do MVP |

**Leitura de cronograma:** viável por abordagem incremental, priorizando requisitos Must do DRP.

---

### 3.6 Viabilidade Humana

| Critério | Avaliação | Evidência |
| -------- | --------- | --------- |
| Capacidade técnica da equipe | Média/Alta | Equipe consegue executar o MVP com escopo controlado e foco em validações essenciais |
| Disponibilidade para execução | Média | Há risco de atraso por acúmulo de atividades, exigindo planejamento por fase |
| Aderência dos usuários internos | Média/Alta | Usuários possuem conhecimento básico e demandam fluxo simples com treinamento objetivo |
| Compreensão das novas regras operacionais | Média | Equipe precisa treinamento objetivo para uso de filial, responsáveis e capacidade ativa |
| Continuidade de operação | Viável com suporte inicial | Implantação assistida reduz resistência e erros no início do uso |

**Conclusão humana:** viável, condicionada a treinamento inicial e acompanhamento nas primeiras semanas de uso.

---

## 4. Matriz de Riscos de Viabilidade

| ID | Risco | Probabilidade | Impacto | Mitigação |
| -- | ----- | ------------- | ------- | --------- |
| RV01 | Interface não aderente ao nível técnico do usuário | Média | Alto | Prototipar fluxo principal, validar com cliente e simplificar telas |
| RV02 | Atraso de cronograma | Média | Alto | Entrega por fases, controle semanal e congelamento do escopo do MVP |
| RV03 | Queda de banco de dados | Baixa/Média | Alto | Backup automático, monitoramento e plano de recuperação |
| RV04 | Duplicidade de cadastro (placa/cliente) | Média | Médio | Regras de unicidade e validações obrigatórias |
| RV05 | Reenvio indevido de notificações | Média | Médio | Controle de idempotência e registro de envio |
| RV06 | Vulnerabilidades de segurança | Baixa/Média | Alto | Boas práticas de autenticação, criptografia de senha e HTTPS |
| RV07 | Resistência à cobrança antecipada de 30% | Alta | Alto | Validar política comercial e implementar com termo explícito |
| RV08 | Dependência de internet estável no local | Média | Médio | Comunicação de indisponibilidade e rotina operacional de contingência |
| RV09 | Sobrecarga ou indisponibilidade da equipe | Média | Médio/Alto | Planejamento por fases, definição de responsáveis e checkpoints semanais |
| RV10 | Configuração incorreta de células ativas por filial | Média | Alto | Limite obrigatório de 1 a 100, valor inicial padrão e revisão operacional periódica |
| RV11 | Agendamento duplicado do mesmo veículo no mesmo horário na mesma ou em outra filial | Média | Alto | Seleção obrigatória de filial e validação de conflito global de veículo por data/hora |

---

## 5. Critérios de Decisão Go/No-Go

| Critério | Condição para Go |
| -------- | ---------------- |
| Viabilidade técnica | Arquitetura web, validações críticas e testes de negócio para regras multiunidade e responsável definidos e aprovados |
| Viabilidade operacional | Fluxo de uso compreendido e aceito por proprietário e equipe |
| Viabilidade econômica | Benefícios esperados superam custos recorrentes previstos |
| Viabilidade legal | Requisitos mínimos de proteção de dados e conformidade atendidos |
| Viabilidade de cronograma | Escopo Must do MVP fechado e planejado por fases |
| Viabilidade humana | Equipe e usuários com treinamento e capacidade para adoção contínua |
| Riscos críticos | Plano de mitigação definido para riscos de alto impacto |
| Pendências comerciais | Regra de 30% validada formalmente antes da automação completa |
| Governança multiunidade | Filiais cadastradas, capacidade ativa parametrizada, regra de conflito global validada e testes de negócio críticos aprovados |

---

## 6. Conclusão e Recomendação

Com base nos insumos levantados, o projeto **CarWash é viável** para continuidade, com recomendação de decisão **Go Condicional**.

Condições para execução segura:

- Priorizar MVP com escopo Must do DRP;
- Conduzir implantação assistida com treinamento breve da equipe;
- Formalizar a política comercial de pré-pagamento (30%) antes da automação integral;
- Validar cadastro inicial de filiais e parametrização de células ativas por unidade;
- Garantir bloqueio de conflito do mesmo veículo no mesmo horário na mesma filial e entre filiais;
- Garantir que responsável seja cadastrado no cliente titular (Nome, Telefone e CPF ou RG) e selecionado no agendamento;
- Executar testes de negócio para validações críticas de filial obrigatória, capacidade por filial e conflito global de agendamento;
- Implementar controles mínimos de segurança, disponibilidade e validação de dados desde a primeira versão.

Com essas condições atendidas, a tendência é de ganho operacional direto por organização da agenda, centralização cadastral e melhoria de previsibilidade do negócio.

---

## 7. Aprovação do Documento

| Papel        | Nome | Data | Assinatura |
| ------------ | ---- | ---- | ---------- |
| Autor        |      |      |            |
| Proprietário |      |      |            |
| Orientador   |      |      |            |
