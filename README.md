# LeRythmeDesLimbes

## Pour utiliser GIT : (si vous etes sur windows installer Git Bash ici : "Git for Windows Setup" - https://git-scm.com/download/win )

:warning: | Ne pas travailler à 2 sur le même fichier est préférable
:---: | :---

### Avant toute chose si vous ne l'avez pas fait :
  - Ajoutez votre nom et votre email pour faire savoir à Git qui vous êtes avec : `git config --global user.name "<votre nom (le même que GitHub)>"` et `git config --global user.email "<votre email (la même que sur GitHub)>"`

### Pour initialiser git :
  - On se déplace dans le dossier où l'on souhaite télécharger le dossier git (avec `cd` comme en bash)
  - Puis on tape : `git clone <l'url du github>` (si vous avez un vieux compte GitHub et que vous avez une erreur parce que il veux passer en ssh au lieu de https, vous pouvez faire les 4 commandes notez ici : https://gist.github.com/taoyuan/bfa3ff87e4b5611b5cbe)

- (si vous avez un vieux compte GitHub et que vous avez une erreur parce que il veux passer en ssh au lieu de https, vous pouvez faire les 4 commandes notez ici : https://gist.github.com/taoyuan/bfa3ff87e4b5611b5cbe)

### Quand on ajoute un nouveau fichier dans son dossier :
  - On tape : `git add *` OU `git add <nom du fichier>` pour que git prennent en compte les nouveaux fichiers/ce fichier

### Quand vous voulez upload votre dossier local sur GitHub :
  - Commencer par faire un commit : `git commit -m "<description des changements>"` (très important de faire un changement avec une description concise et précise)
  - Puis pour push les changements sur github tapez : `git push`

### Quand vous voulez download le GitHub sur votre ordinateur en local :
  - Simplement tapez : `git pull`

### Quand vous voulez annuler un commit qui à été effectuer :
  - Vous pouvez regarder la liste des commits effectuer avec `git log` et notez le hash correspondant au commit en question
  - Ensuite tapez : `git revert <le hash du commit>`

## Concernant les branches pour Git :

### Créer une branche : (à éviter de faire sur un terminal Git, je pense c'est mieux de le faire sur GitHub)
  - `git branch <nom de la branche>` (ne pas oublier de push apres je pense)

### Se positionner sur une branche :
  - `git checkout <nom de la branche>`

### Fusionner deux branches (à éviter de faire seul dans son coin) :
  - On se positionne sur la branche qui va recevoir l'autre branche et on tape : `git merge <l'autre branche>`
