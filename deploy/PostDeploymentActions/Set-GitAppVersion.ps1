$o = @{}
$o.ShortHash = git.exe log -1 --pretty=format:%h;
$o.FullHash = git.exe log -1 --pretty=format:%H;
$o.Subject = git.exe log -1 --pretty=format:%s;
$o.AuthorName = git.exe log -1 --pretty=format:%an;
$o.AuthorEmail = git.exe log -1 --pretty=format:%ae;
$o.DeploymentUtc = Get-UtcDate -format u;

$o | ConvertTo-Json | Out-File "D:\home\site\wwwroot\version.json";
