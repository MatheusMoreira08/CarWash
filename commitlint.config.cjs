// commitlint — valida Conventional Commits no commit-msg hook e no CI.
// Regras alinhadas a CONTRIBUTING.md §2.
module.exports = {
  extends: ['@commitlint/config-conventional'],
  rules: {
    // Tipos permitidos no monolito
    'type-enum': [
      2,
      'always',
      [
        'feat',
        'fix',
        'docs',
        'style',
        'refactor',
        'test',
        'chore',
        'build',
        'ci',
        'perf',
        'revert',
      ],
    ],

    // Escopos do monolito — um único, obrigatório
    'scope-enum': [
      2,
      'always',
      [
        'back',
        'front',
        'db',
        'infra',
        'ci',
        'docs',
        'agents',
        'deps',
        'auth',
      ],
    ],
    'scope-empty': [2, 'never'],

    // Estilo da mensagem
    'subject-case': [2, 'never', ['upper-case', 'pascal-case', 'start-case']],
    'subject-empty': [2, 'never'],
    'subject-full-stop': [2, 'never', '.'],
    'subject-max-length': [2, 'always', 72],
    'header-max-length': [2, 'always', 100],

    // Body e footer
    'body-leading-blank': [2, 'always'],
    'body-max-line-length': [1, 'always', 100],
    'footer-leading-blank': [2, 'always'],
    'footer-max-line-length': [1, 'always', 100],
  },
};
