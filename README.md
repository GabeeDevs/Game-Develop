# Levantamento de Requisitos - Projeto TCC

Este documento apresenta os requisitos funcionais e não funcionais para o desenvolvimento de um jogo inspirado em Fall Guys, com suporte para dois jogadores (splitscreen e LAN). O projeto deve ser concluído em aproximadamente 1,5 meses, portanto, o foco é em um escopo mínimo e viável.

---

## Requisitos Funcionais 

### 1. Modos de Jogo
- **Splitscreen:** Dois jogadores jogando na mesma máquina, com divisão de tela.
- **Multiplayer LAN:** Implementação de conexão básica para partidas locais, utilizando soluções nativas ou bibliotecas como o *Netcode for GameObjects* ou *Mirror*, priorizando a simplicidade e robustez.

### 2. Mecânicas Básicas de Jogo
- **Movimentação dos Personagens:**  
  - Controle simples (andar, pular, correr) com resposta imediata.
- **Interação com o Ambiente:**  
  - Utilização do sistema de física e colisões do Unity para interações com obstáculos e plataformas (ex.: saltos e colisões simples).
- **Desafios e Obstáculos:**  
  - Criação de uma ou duas fases curtas com obstáculos simples (ex.: plataformas móveis, obstáculos fixos) para simular o estilo “Fall Guys”.
- **Eliminação e Checkpoints:**  
  - Sistema básico que elimina o jogador ao errar ou atingir limites pré-definidos.
  - Implementação mínima de pontos de verificação, se aplicável.

### 3. Interface e Feedback Visual
- **Tela Inicial:**  
  - Menu com opções de “Jogar”, “Configurações” e “Sair”.
- **HUD Simples:**  
  - Exibição de informações essenciais, como tempo restante, posição dos jogadores ou mensagens de alerta.
- **Feedback de Eventos:**  
  - Indicações claras para eventos importantes (ex.: eliminação ou vitória).

### 4. Configurações e Conectividade
- **Opções de Configuração:**  
  - Ajustes rápidos de parâmetros (ex.: sensibilidade dos controles) e escolha entre splitscreen e LAN.
- **Sincronização de Estado:**  
  - Implementação de sincronização básica dos estados dos jogadores e dos objetos interativos, priorizando a estabilidade.

---

## Requisitos Não Funcionais 

### 1. Desempenho e Otimização
- **Frame Rate:**  
  - Garantir uma taxa mínima de 30 FPS, otimizando cenários e modelos para evitar sobrecarga.
- **Escalabilidade:**  
  - Manter os elementos do jogo simples para reduzir a carga de processamento, considerando o tempo limitado de desenvolvimento.

### 2. Facilidade de Desenvolvimento
- **Uso de Ferramentas Nativas:**  
  - Maximizar o uso das ferramentas e bibliotecas já disponíveis no Unity (sistema de física, UI, rede) para acelerar a implementação.
- **Documentação e Organização:**  
  - Estruturar o código de forma modular, facilitando futuras manutenções e ajustes.

### 3. Compatibilidade e Portabilidade
- **Plataforma Alvo:**  
  - Foco inicial no desenvolvimento para Windows, garantindo compatibilidade com PCs de desempenho médio.

### 4. Manutenibilidade e Testabilidade
- **Código Modular:**  
  - Separar funcionalidades (ex.: controle de personagens, rede, interface) para facilitar testes e ajustes.
- **Testes de Integração:**  
  - Reservar tempo para testes simples que garantam a estabilidade do modo multiplayer, mesmo que de forma limitada.


