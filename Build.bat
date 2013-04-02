msbuild OpenRcp.sln /t:clean
FOR /D %%p IN ("Build\*.*") DO rmdir "%%p" /s /q
rmdir Build /s /q
msbuild OpenRcp.sln /p:Configuration=Release
#xcopy "Libs"  "Build\External" /E /Y /I /R