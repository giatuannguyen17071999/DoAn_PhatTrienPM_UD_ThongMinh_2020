asdf

---------
git fetch origin
git checkout -b viet origin/viet
git merge master
Step 2: Merge the changes and update on GitHub.

git checkout master
git merge --no-ff viet
git push origin master