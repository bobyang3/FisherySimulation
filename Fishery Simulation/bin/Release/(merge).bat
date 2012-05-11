REM http://stackoverflow.com/questions/10137937/c-merge-dll-into-exe-beginners-guide-needed
REM Open CMD and cd to your directory. Let's say: cd C:\test
REM Insert the below code.
REM /out:finish.exe | replace finish.exe with any filename you want.
REM Behind the /out:finish.exe you have to give the files you want to be combined.

del "%CD%\FisherySimulation.exe"

c:
C:\__STANDALONE__\_PROGRAMMING_\MS_ILMerge\ILMerge.exe /target:winexe /targetplatform:"v4,C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /out:FisherySimulation.exe "Fishery Simulation.exe" "IPlugins.dll"

pause

